﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Entidades
    {
        private States _State;

        public States State
        {
            get { return _State; }
            set { _State = value; }
        }
        public enum States
        {
            Deleted,
            New,
            Modified,
            Unmodified
        }
    }
}
