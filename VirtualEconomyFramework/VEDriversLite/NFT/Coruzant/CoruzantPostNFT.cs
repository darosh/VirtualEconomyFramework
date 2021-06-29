﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace VEDriversLite.NFT.Coruzant
{
    public class CoruzantPostNFT : CommonCoruzantNFT
    {
        public CoruzantPostNFT(string utxo)
        {
            Utxo = utxo;
            Type = NFTTypes.CoruzantPost;
            TypeText = "NFT CoruzantPost";
            TokenId = "La9ADonmDwxsNKJGvnRWy8gmWmeo72AEeg8cK7";
        }

        public override async Task Fill(INFT NFT)
        {
            await FillCommon(NFT);

            LastComment = (NFT as CoruzantPostNFT).LastComment;
            LastCommentBy = (NFT as CoruzantPostNFT).LastCommentBy;
            FullPostLink = (NFT as CoruzantPostNFT).FullPostLink;
            PodcastLink = (NFT as CoruzantPostNFT).PodcastLink;
            AuthorProfileUtxo = (NFT as CoruzantPostNFT).AuthorProfileUtxo;
        }

        public string AuthorProfileUtxo { get; set; } = string.Empty;
        public string FullPostLink { get; set; } = string.Empty;
        public string LastComment { get; set; } = string.Empty;
        public string LastCommentBy { get; set; } = string.Empty;


        private void ParseSpecific(IDictionary<string, string> meta)
        {
            if (meta.TryGetValue("AuthorProfileUtxo", out var pu))
                AuthorProfileUtxo = pu;
            if (meta.TryGetValue("LastComment", out var lc))
                LastComment = lc;
            if (meta.TryGetValue("LastCommentBy", out var lcb))
                LastCommentBy = lcb;
            if (meta.TryGetValue("FullPostLink", out var fpl))
                FullPostLink = fpl;
            if (meta.TryGetValue("PodcastLink", out var pdl))
                PodcastLink = pdl;
        }

        public override async Task ParseOriginData(IDictionary<string, string> lastmetadata)
        {
            var nftData = await NFTHelpers.LoadNFTOriginData(Utxo);
            if (nftData != null)
            {
                ParseCommon(nftData.NFTMetadata);

                if (lastmetadata.TryGetValue("Price", out var price))
                {
                    if (!string.IsNullOrEmpty(price))
                    {
                        price = price.Replace(',', '.');
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

                SourceTxId = nftData.SourceTxId;
                NFTOriginTxId = nftData.NFTOriginTxId;
            }
            ParseSpecific(nftData.NFTMetadata);
        }

        public async Task GetLastData()
        {
            var nftData = await NFTHelpers.LoadLastData(Utxo);
            if (nftData != null)
            {
                ParseCommon(nftData.NFTMetadata);

                if (nftData.NFTMetadata.TryGetValue("Price", out var price))
                {
                    if (!string.IsNullOrEmpty(price))
                    {
                        price = price.Replace(',', '.');
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

                SourceTxId = nftData.SourceTxId;
                NFTOriginTxId = nftData.NFTOriginTxId;
            }
            ParseSpecific(nftData.NFTMetadata);
        }

        public async Task LoadLastData(Dictionary<string, string> metadata)
        {
            if (metadata != null)
            {
                ParseCommon(metadata);

                if (metadata.TryGetValue("SourceUtxo", out var su))
                {
                    SourceTxId = Utxo;
                    NFTOriginTxId = su;
                }
                else
                {
                    SourceTxId = Utxo;
                    NFTOriginTxId = Utxo;
                }
                if (metadata.TryGetValue("Price", out var price))
                {
                    if (!string.IsNullOrEmpty(price))
                    {
                        price = price.Replace(',', '.');
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

                ParseSpecific(metadata);
            }
        }

        public override async Task<IDictionary<string, string>> GetMetadata(string address = "", string key = "", string receiver = "")
        {
            if (string.IsNullOrEmpty(ImageLink))
                throw new Exception("Cannot create NFT CoruzantPost without image link.");
            if (string.IsNullOrEmpty(Name))
                throw new Exception("Cannot create NFT CoruzantPost without Name");
            if (string.IsNullOrEmpty(Description))
                throw new Exception("Cannot create NFT CoruzantPost without Description.");
            if (string.IsNullOrEmpty(Author))
                throw new Exception("Cannot create NFT CoruzantPost without author.");
            if (string.IsNullOrEmpty(AuthorProfileUtxo))
                throw new Exception("Cannot create NFT CoruzantPost without Author Profile Utxo.");
            if (string.IsNullOrEmpty(FullPostLink))
                throw new Exception("Cannot create NFT CoruzantPost without Full Post Link.");
            if (LastComment.Length > 250)
                throw new Exception("Cannot create NFT CoruzantPost. Comment must be shorter than 250 characters.");
            if (Description.Length > 250)
                throw new Exception("Cannot create NFT CoruzantPost. Description must be shorter than 250 characters.");

            var metadata = new Dictionary<string, string>();
            metadata.Add("NFT", "true");
            metadata.Add("Type", "NFT CoruzantPost");
            metadata.Add("Name", Name);
            metadata.Add("Author", Author);
            metadata.Add("Description", Description);
            metadata.Add("Image", ImageLink);
            metadata.Add("Link", Link);
            if (!string.IsNullOrEmpty(FullPostLink))
                metadata.Add("FullPostLink", FullPostLink);
            if (!string.IsNullOrEmpty(PodcastLink))
                metadata.Add("PodcastLink", PodcastLink);
            if (!string.IsNullOrEmpty(AuthorProfileUtxo))
                metadata.Add("AuthorProfileUtxo", AuthorProfileUtxo);
            if (!string.IsNullOrEmpty(LastCommentBy))
                metadata.Add("LastCommentBy", LastCommentBy);
            if (!string.IsNullOrEmpty(LastComment))
                metadata.Add("LastComment", LastComment);

            if (Price > 0)
                metadata.Add("Price", Price.ToString(CultureInfo.InvariantCulture));

            return metadata;
        }
    }
}
