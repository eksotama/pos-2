﻿using System;
using System.Collections.Generic;
using System.Text;

namespace pos
{
    public class ListItem
    {
        public int Id { get; set; }
        public string Photo_Path { get; set; }

        public string Title { get; set; }

        public dynamic Detail { get; set; }
    }
}