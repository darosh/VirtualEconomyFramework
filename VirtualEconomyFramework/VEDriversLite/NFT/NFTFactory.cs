﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace VEDriversLite.NFT
{
    public static class NFTFactory
    {
        public static async Task<INFT> GetNFT(string tokenId, string utxo)
        {
            NFTTypes type = NFTTypes.Image;

            var meta = await NeblioTransactionHelpers.GetTransactionMetadata(tokenId, utxo);
            
            if (meta == null)
            {
                return null;
            }

            if (meta.TryGetValue("Type", out var t))
            {
                if (!string.IsNullOrEmpty(t))
                {
                    switch (t)
                    {
                        case "NFT Profile":
                            type = NFTTypes.Profile;
                            break;
                        case "NFT Post":
                            type = NFTTypes.Post;
                            break;
                        case "NFT Image":
                            type = NFTTypes.Image;
                            break;
                        case "NFT Payment":
                            type = NFTTypes.Payment;
                            break;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                if (meta.TryGetValue("SourceUtxo", out var sourceutxo))
                {
                    type = NFTTypes.Image;
                }
                else
                {
                    return null;
                }
            }

            var Price = 0.0;
            var PriceActive = false;
            if (meta.TryGetValue("Price", out var price))
            {
                if (!string.IsNullOrEmpty(price))
                {
                    Price = double.Parse(price, CultureInfo.InvariantCulture);
                    PriceActive = true;
                }
                else
                {
                    PriceActive = false;
                }
            }
            else
            {
                PriceActive = false;
            }

            switch (type)
            {
                case NFTTypes.Image:
                    var nft = new ImageNFT(utxo);
                    await nft.ParseOriginData();
                    nft.Price = Price;
                    nft.PriceActive = PriceActive;
                    if (!string.IsNullOrEmpty(nft.NFTOriginTxId))
                        return nft;
                    else
                        return null;
                case NFTTypes.Profile:
                    var pnft = new ProfileNFT(utxo);
                    //await pnft.ParseOriginData();
                    await pnft.LoadLastData(meta);
                    return pnft;
                case NFTTypes.Post:
                    var ponft = new PostNFT(utxo);
                    //await ponft.ParseOriginData();
                    await ponft.LoadLastData(meta);
                    return ponft;
                case NFTTypes.Payment:
                    var pmnft = new PaymentNFT(utxo);
                    await pmnft.LoadLastData(meta);
                    return pmnft;
            }

            return null;
        }
    }
}
