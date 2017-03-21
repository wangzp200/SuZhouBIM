using System;

namespace BIMWebService.Mode.Sys
{
    [Serializable]
    public class EntryInfo
    {
        public BoIssueMethod BoIssue;
        public BoItemTreeTypes BoItemTree;
        public BoYesNoEnum BoYesNo;
        public BaseEntry BaseEntry;
        public ProductTree ProductTree;
    }
}