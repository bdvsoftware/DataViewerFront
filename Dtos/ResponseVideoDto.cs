﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataViewerFront.Dtos
{
    internal class ResponseVideoDto
    {
        public int VideoId { get; set; }
        public string VideoName { get; set; }
        public int SessionId { get; set; }
        public string SessionName { get; set; }
        public DateOnly Date { get; set; }
        public string GpName { get; set; }
        public string Status { get; set; }
        public bool ShowPlayer { get; set; }

        public ResponseVideoDto(int videoId, string videoName, int sessionId, string sessionName, DateOnly date, string gpName, string status, bool showPlayer)
        {
            VideoId = videoId;
            VideoName = videoName;
            SessionId = sessionId;
            SessionName = sessionName;
            Date = date;
            GpName = gpName;
            Status = status;
            ShowPlayer = showPlayer;
        }
    }
}
