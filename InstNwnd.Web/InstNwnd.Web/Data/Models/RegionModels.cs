﻿namespace InstNwnd.Web.Data.Models.RegionCrud
{
    public class RegionModels
    {
        public int RegionId { get; set; }
        public string RegionDescription { get; set; }
        public object Description { get; internal set; }
        public object RegionName { get; internal set; }
    }
}
