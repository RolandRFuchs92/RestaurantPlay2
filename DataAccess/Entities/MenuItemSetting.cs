﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class MenuItemSetting
    {
        [Key]
        public int MenuItemSettingId { get; set; }
        public bool MenuItemSettingIsActive { get; set; }
        public bool MenuItemSettingDisplayImage { get; set; }
        public bool MenuItemSettingDisplayPrice { get; set; }
        public int MenuItemId { get; set; }
    }
}
