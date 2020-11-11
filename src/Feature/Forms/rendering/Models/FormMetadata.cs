using Sitecore.LayoutService.Client.Response.Model;
using System;
using System.Collections.Generic;

namespace Mvp.Feature.Forms.Models
{
    public class FormMetadata
    {
        public bool IsAjax { get; set; }
        public bool IsTrackingEnabled { get; set; }
        public bool IsRobotDetectionAvailable { get; set; }
        public bool IsRobotDetectionEnabled { get; set; }
        public bool IsTemplate { get; set; }
        public string Title { get; set; }
        public string CssClass { get; set; }
        public string Thumbnail { get; set; }
        public List<string> Scripts { get; set; }
        public List<string> Styles { get; set; }
        public Guid ItemId { get; set; }
        public Guid TemplateId { get; set; }
        public Guid FieldTypeItemId { get; set; }
        public string Name { get; set; }
    }
}
