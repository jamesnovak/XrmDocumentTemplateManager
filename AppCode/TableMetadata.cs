using Microsoft.Xrm.Sdk.Metadata;
using System;

namespace Futurez.Xrm.Tools.AppCode
{
    public class TableMetadata
    {
        public TableMetadata(EntityMetadata emd)
        {
            Metadata = emd;
        }

        public EntityMetadata Metadata { get; private set; }

        public override string ToString()
        {
            return $"{Metadata.DisplayName?.UserLocalizedLabel?.Label ?? "N/A"} ({Metadata.SchemaName})";
        }
    }
}