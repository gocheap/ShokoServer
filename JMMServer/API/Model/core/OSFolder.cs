﻿using System.Collections.Generic;

namespace JMMServer.API.Model.core
{
    public class OSFolder
    {
        public string dir { get; set; }
        public string full_path { get; set; }
        public List<OSFolder> subdir { get; set; }
    }
}
