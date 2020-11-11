using Mvp.Feature.Forms.Models;
using System;
using System.Collections.Generic;

namespace Mvp.Feature.Forms
{
    public static class Constants
    {
        public static readonly Dictionary<Guid, FormFieldTypes> FieldTypes = new Dictionary<Guid, FormFieldTypes>
        {
            //{ new Guid("{447AA745-6D29-4B65-A5A3-8173AA8AF548})", FormFieldTypes.Section },
            //{ new Guid("{983BFA5F-C6B6-4AEE-A3BB-46B95D52E7DF})", FormFieldTypes.TextField },
            //{ new Guid("{7E9A0903-A52C-4843-BBE1-5B26BD162BED})", FormFieldTypes.FileUpload },
            { new Guid("{7CE25CAB-EF3A-4F73-AB13-D33BDC1E4EE2}"), FormFieldTypes.Button },
            { new Guid("{4EE89EA7-CEFE-4C8E-8532-467EF64591FC}"), FormFieldTypes.SingleLineText },
            { new Guid("{A296A1C1-0DA0-4493-A92E-B8191F43AEC6}"), FormFieldTypes.MultipleLineText },
            //{ new Guid("{38137D30-7B2A-47D5-BBD8-133252C01B28})", FormFieldTypes.DateField },
            { new Guid("{04C39CAC-8976-4910-BE0D-879ED3368429}"), FormFieldTypes.Email },
            //{ new Guid("{5B153FC0-FC3F-474F-8CB8-233FB1BEF292}"), FormFieldTypes.NumberField },
            //{ new Guid("{4DA85E8A-3B48-4BC6-9565-8C1F5F36DD1B}"), FormFieldTypes.Checkbox },
            //{ new Guid("{DF74F55B-47E6-4D1C-92F8-B0D46A7B2704}"), FormFieldTypes.Telephone },
            //{ new Guid("{E0CFADEE-1AC0-471D-A820-2E70D1547B4B}"), FormFieldTypes.DropdownList },
            //{ new Guid("{D86A361A-D4FF-46B2-9E97-A37FC5B1FE1A}"), FormFieldTypes.CheckboxList },
            //{ new Guid("{222A2121-D370-4C6F-80A3-03C930B718BF}"), FormFieldTypes.ListBox },
            //{ new Guid("{EDBD38A8-1AE9-42EC-8CCD-F5B0E2998B4F}"), FormFieldTypes.RadioButtonList },
            { new Guid("{668A1C37-9D6B-483B-B7C1-340C92D04BA4}"), FormFieldTypes.Password }
        };
    }
}
