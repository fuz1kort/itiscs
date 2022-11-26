﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha910
{
    class SpeedMPS
    {
        private double mps;

        public SpeedMPS(double mps) => this.mps = mps;

        public void FromKmH(double kmh) => this.mps =kmh / 3.6;

        public void FromMpH(double mph) => this.mps = mph / 3.6 * 1.609;

        public double Kmh { get => mps / 3.6; }

        public double Mps { get => mps; set { mps = value; } }

        public double Mph { get => mps / 3.6 * 1.609; }

        public static SpeedMPS operator +(SpeedMPS mps1, SpeedMPS mps2) => new SpeedMPS(mps1.Mps + mps2.Mps);

        public static SpeedMPS operator -(SpeedMPS mps1, SpeedMPS mps2) => new SpeedMPS(mps1.Mps - mps2.Mps);
    }
}
