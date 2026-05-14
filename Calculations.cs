using System;
using System.Collections.Generic;

namespace BoilerCalc
{
    internal class Calculations
    {
        /// <summary>
        /// Расчёт теоретических объёмов воздуха и продуктов сгорания
        /// </summary>
        public static (double, double, double, double, double) CalculateAirParameters(
            double CP, double SP, double HP, double OP, double WP, double AP, double NP, double QPh)
        {
            double terOB = Math.Round(0.0889 * (CP + 0.375 * SP) + 0.256 * HP - 0.0333 * OP, 2);
            double terORO2 = Math.Round(0.0186 * (CP + 0.375 * SP), 2);
            double terON2 = 0.79 * terOB + 0.008 * NP;
            double terOH2O = Math.Round(0.111 * HP + 0.0124 * WP + 0.0161 * terOB, 3);
            double terOr = terORO2 + terON2 + terOH2O;
            return (terOB, terORO2, terON2, terOH2O, terOr);
        }

        /// <summary>
        /// Таблица 5 - Объёмы газов по газоходам (8 газоходов)
        /// </summary>
        public static (double[,], string) Tablica5(
            double aT, double DaPP, double DaVE, double DaVP,
            double terOH2O, double terOB, double terOr, double terORO2,
            double AP, double aYN)
        {
            int n = 8;
            double[,] tabl5 = new double[9, n];
            double a = aT;
            double DaPP_ = DaPP / 2, DaVE_ = DaVE / 2, DaVP_ = DaVP / 2;

            tabl5[0, 0] = a;                    // Топка
            a += DaPP_; tabl5[0, 1] = a;        // КПП I
            a += DaPP_; tabl5[0, 2] = a;        // КПП II
            a += DaVE_; tabl5[0, 3] = a;        // ВЭК II
            a += DaVP_; tabl5[0, 4] = a;        // ВЗП II
            a += DaVE_; tabl5[0, 5] = a;        // ВЭК I
            a += DaVP_; tabl5[0, 6] = a;        // ВЗП I
            tabl5[0, 7] = a;                    // Дымосос

            tabl5[1, 0] = aT;
            for (int i = 1; i < n; i++)
                tabl5[1, i] = (tabl5[0, i - 1] + tabl5[0, i]) / 2.0;

            for (int i = 0; i < n; i++)
            {
                tabl5[2, i] = Math.Round(terOH2O + 0.0161 * (tabl5[1, i] - 1) * terOB, 4);
                tabl5[3, i] = Math.Round(terOr + 0.0161 * (tabl5[1, i] - 1) * terOB, 4);
                double rRO2 = tabl5[3, i] > 0 ? terORO2 / tabl5[3, i] : 0;
                tabl5[4, i] = Math.Round(rRO2, 4);
                double rH2O = tabl5[3, i] > 0 ? tabl5[2, i] / tabl5[3, i] : 0;
                tabl5[5, i] = Math.Round(rH2O, 4);
                tabl5[6, i] = Math.Round(tabl5[4, i] + tabl5[5, i], 4);
                tabl5[8, i] = Math.Round(1 - AP / 100 + 1.306 * tabl5[1, i] * terOB, 4);
                tabl5[7, i] = tabl5[8, i] > 0 ? Math.Round((AP * aYN) / (100 * tabl5[8, i]), 4) : 0;
            }
            return (tabl5, null);
        }

        /// <summary>
        /// Таблица 6 - Энтальпии продуктов сгорания
        /// </summary>
        public static (double[,], string) Tablica6(
            double AP, double terOB, double aYN,
            double terORO2, double terON2, double terOH2O,
            double aT, double[,] tabl5)
        {
            double[,] sT1 = new double[13, 20];
            for (int i = 0; i < 20; i++) sT1[0, i] = 100 + i * 100;

            for (int i = 0; i < 20; i++)
            {
                double temp = sT1[0, i];
                var gp = WaterSteamTables.InterpolateGasProperties(temp);
                double Ig0 = terORO2 * gp.IkRO2 + terON2 * gp.IkN2 + terOH2O * gp.IkH2O;
                sT1[1, i] = Ig0;
                double Iv0 = terOB * gp.IkAir;
                sT1[2, i] = Iv0;
                var ap = WaterSteamTables.InterpolateAshProperties(temp);
                double Izl = (AP / 100.0) * aYN * ap.IAsh;
                sT1[3, i] = Izl;
                sT1[4, i] = Ig0 + Izl;

                int maxGasPasses = (tabl5 != null && tabl5.GetLength(1) > 0) ? tabl5.GetLength(1) : 8;
                for (int j = 0; j < maxGasPasses && (5 + j) < sT1.GetLength(0); j++)
                {
                    double alpha = (tabl5 != null && tabl5.GetLength(0) > 0 && j < maxGasPasses)
                        ? tabl5[0, j] : aT + j * 0.05;
                    sT1[5 + j, i] = Ig0 + (alpha - 1) * Iv0 + Izl;
                }
            }
            return (sT1, null);
        }

        /// <summary>
        /// Таблица 7 - Тепловой баланс котла
        /// </summary>
        public static (double[], string) Tablica7(
            double KiloDJ, double KiloKal, double TempUG, double TempHolV,
            double q3, double q4, double aYN, double[,] ST1, double AP,
            double alphaT, double[] tabl5Row0)
        {
            double[] tabl7 = new double[23];
            tabl7[0] = KiloDJ;
            tabl7[1] = KiloKal;
            tabl7[2] = q3;
            tabl7[3] = q4;

            double D = Global.QBoiler > 0 ? Global.QBoiler : 75;
            double q5;
            if (D <= 1) q5 = 8.0;
            else if (D <= 2) q5 = 6.0;
            else if (D <= 4) q5 = 4.5;
            else if (D <= 6) q5 = 3.5;
            else if (D <= 10) q5 = 2.5;
            else if (D <= 20) q5 = 1.8;
            else if (D <= 30) q5 = 1.5;
            else if (D <= 50) q5 = 1.2;
            else if (D <= 75) q5 = 0.9;
            else if (D <= 100) q5 = 0.7;
            else if (D <= 160) q5 = 0.55;
            else if (D <= 210) q5 = 0.45;
            else if (D <= 270) q5 = 0.35;
            else q5 = 0.3;
            tabl7[4] = q5;

            tabl7[6] = TempUG;
            tabl7[8] = TempHolV;

            double entalpyUG = InterpolateEnthalpyByTemp(ST1, TempUG, 11);
            tabl7[7] = Math.Round(entalpyUG, 1);
            double entalpyHV = InterpolateEnthalpyByTemp(ST1, TempHolV, 2);
            tabl7[9] = Math.Round(entalpyHV, 1);
            tabl7[10] = Math.Round(entalpyHV * 0.5, 1);

            tabl7[11] = Math.Round(1 - aYN, 3);
            double tempZol = 600;
            var ashP = WaterSteamTables.InterpolateAshProperties(tempZol);
            double udEzol = ashP.IAsh;
            tabl7[22] = udEzol;

            tabl7[5] = Math.Round((tabl7[11] * udEzol * AP) / (tabl7[0] > 0 ? tabl7[0] : 1), 3);
            if (tabl7[5] < 0) tabl7[5] = 0;
            tabl7[13] = Math.Round(AP / 100 * aYN * udEzol, 1);

            double alphaUHG = tabl5Row0 != null && tabl5Row0.Length > 6 ? tabl5Row0[6] : alphaT;
            tabl7[14] = Math.Round(((tabl7[7] - alphaUHG * tabl7[9]) * (100 - q4)) / (tabl7[0] > 0 ? tabl7[0] : 1), 2);
            if (tabl7[14] < 0) tabl7[14] = 0;

            double etaBr = 100 - (tabl7[14] + q3 + q4 + q5 + tabl7[5]);
            tabl7[15] = Math.Round(Math.Max(0, Math.Min(100, etaBr)), 2);

            double DkgS = D * 1000.0 / 3600.0;
            double QKa = DkgS * (Global.IPerPar - Global.IPitV);
            tabl7[16] = Math.Round(QKa, 0);

            double B = (QKa * 100.0) / (tabl7[15] * tabl7[0]);
            tabl7[17] = Math.Round(B, 4);
            tabl7[18] = Math.Round(B * 3600, 2);
            double Br = B * (1 - q4 / 100.0);
            tabl7[19] = Math.Round(Br, 4);
            tabl7[20] = Math.Round(Br * 3600, 2);
            double phi = (tabl7[15] + q5) > 0 ? (1 - q5 / (tabl7[15] + q5)) : 0.99;
            tabl7[21] = Math.Round(phi, 4);

            return (tabl7, null);
        }

        /// <summary>
        /// Таблица 8 - Расчёт воздухоподогревателя (ВЗП I ступени)
        /// </summary>
        public static double[,] Tablica8(double Bp, double phi, double[,] ST1,
            double alphaVZP, double DaVPstep, double Ixv0, double Vg)
        {
            double[,] t8 = new double[15, 3];

            // Типовые параметры ВЗП: d=40мм, S1=60мм, S2=45мм
            t8[0, 0] = 40;   // d, мм
            t8[1, 0] = 60; t8[1, 1] = 45; // S1/S2
            t8[2, 0] = Math.Round(t8[1, 0] / t8[0, 0], 2); // σ1
            t8[3, 0] = Math.Round(t8[1, 1] / t8[0, 0], 2); // σ2
            t8[4, 0] = 30;  // Z2 - число рядов
            t8[5, 0] = 8.5; // fв, м² (живое сечение для воздуха)
            t8[6, 0] = 6.2; // Fг, м² (живое сечение для газов)
            t8[7, 0] = 1200; t8[7, 1] = 1200; // n1, n2 - кол-во труб

            // Температуры и энтальпии
            double thetaUh = Global.TempUG; // θух''
            t8[8, 0] = thetaUh;
            double Iuh = InterpolateEnthalpyByTemp(ST1, thetaUh, 11);
            t8[9, 0] = Math.Round(Iuh, 0);

            // θ' - на входе в ступень (принимаем ~300°C)
            double thetaIn = 300;
            t8[10, 0] = thetaIn;
            double Iin = InterpolateEnthalpyByTemp(ST1, thetaIn, 11);
            t8[11, 0] = Math.Round(Iin, 0);

            // Q_Б = φ * (I' - I'' + Δα * Iхв^0)
            double Qb = phi * (Iin - Iuh + DaVPstep * Ixv0);
            t8[12, 0] = Math.Round(Qb, 1);

            // Температурный напор
            double tHolV = Global.TempHolV; // tх.в
            double tGv = 30; // tгв - температура горячего воздуха (принимаем)
            double dtB = thetaIn - tGv;
            double dtM = thetaUh - tHolV;
            double dt = dtB - dtM;
            double dtLog = (Math.Abs(dt) > 1) ? dt / Math.Log(dtB / dtM) : (dtB + dtM) / 2;
            t8[13, 0] = Math.Round(dtLog, 0);

            // Коэффициент теплопередачи k (приближённо)
            double k = 25;
            double H = Qb * Bp / (k * dtLog);
            t8[14, 0] = Math.Round(H, 0);

            return t8;
        }

        /// <summary>
        /// Таблица 9 - Расчёт водяного экономайзера (ВЭК I ступени)
        /// </summary>
        public static double[,] Tablica9(double Bp, double phi, double[,] ST1,
            double alphaVEK, double DaVEstep, double Ixv0)
        {
            double[,] t9 = new double[12, 3];
            // d=32мм, S1=80мм, S2=60мм
            t9[0, 0] = 32;
            t9[1, 0] = 80; t9[1, 1] = 60;
            t9[2, 0] = Math.Round(t9[1, 0] / t9[0, 0], 2);
            t9[3, 0] = Math.Round(t9[1, 1] / t9[0, 0], 2);
            t9[4, 0] = 50; // Z2

            double thetaIn = 400;
            double thetaOut = 300;
            t9[5, 0] = thetaIn;
            t9[6, 0] = thetaOut;
            double Iin = InterpolateEnthalpyByTemp(ST1, thetaIn, 11);
            double Iout = InterpolateEnthalpyByTemp(ST1, thetaOut, 11);
            double Qb = phi * (Iin - Iout + DaVEstep * Ixv0);
            t9[7, 0] = Math.Round(Qb, 1);

            double tPvIn = Global.TPitV;
            double tPvOut = tPvIn + 30;
            double dtB = thetaIn - tPvOut;
            double dtM = thetaOut - tPvIn;
            double dt = dtB - dtM;
            double dtLog = (Math.Abs(dt) > 1) ? dt / Math.Log(dtB / dtM) : (dtB + dtM) / 2;
            t9[8, 0] = Math.Round(dtLog, 0);

            double k = 45;
            double H = Qb * Bp / (k * dtLog);
            t9[9, 0] = Math.Round(H, 0);

            // Средняя температура газов
            double tAvg = (thetaIn + thetaOut) / 2;
            t9[10, 0] = Math.Round(tAvg, 0);

            // Скорость газов (при F=4.5 м²)
            double Fg = 4.5;
            double w = Bp * 8.0 * (tAvg + 273) / (Fg * 273);
            t9[11, 0] = Math.Round(w, 1);

            return t9;
        }

        /// <summary>
        /// Таблица 10 - Расчёт пароперегревателя (КПП)
        /// </summary>
        public static double[,] Tablica10(double Bp, double phi, double[,] ST1,
            double alphaPP, double DaPPstep, double Ixv0)
        {
            double[,] t10 = new double[12, 3];
            t10[0, 0] = 38; // d, мм
            t10[1, 0] = 70; t10[1, 1] = 60; // S1/S2
            t10[2, 0] = Math.Round(t10[1, 0] / t10[0, 0], 2);
            t10[3, 0] = Math.Round(t10[1, 1] / t10[0, 0], 2);
            t10[4, 0] = 40; // Z2

            double thetaIn = 1000;
            double thetaOut = 700;
            t10[5, 0] = thetaIn;
            t10[6, 0] = thetaOut;
            double Iin = InterpolateEnthalpyByTemp(ST1, thetaIn, 6);
            double Iout = InterpolateEnthalpyByTemp(ST1, thetaOut, 7);
            double Qb = phi * (Iin - Iout + DaPPstep * Ixv0);
            t10[7, 0] = Math.Round(Qb, 1);

            double tPar = Global.TPar;
            double tNas = CalculateSaturationTemp(Global.PPar * 0.0980665);
            double dtB = thetaIn - tPar;
            double dtM = thetaOut - tNas;
            double dt = dtB - dtM;
            double dtLog = (Math.Abs(dt) > 1) ? dt / Math.Log(dtB / dtM) : (dtB + dtM) / 2;
            t10[8, 0] = Math.Round(dtLog, 0);

            double k = 55;
            double H = Qb * Bp / (k * dtLog);
            t10[9, 0] = Math.Round(H, 0);

            double tAvg = (thetaIn + thetaOut) / 2;
            t10[10, 0] = Math.Round(tAvg, 0);

            double Fg = 7.0;
            double w = Bp * 8.0 * (tAvg + 273) / (Fg * 273);
            t10[11, 0] = Math.Round(w, 1);

            return t10;
        }

        /// <summary>
        /// Создание данных для I-θ диаграммы (формат: [температура, I_г^0, I_в^0, I_г(αт), I_зл])
        /// </summary>
        public static double[,] CreateIThetaDiagram(double[,] ST1)
        {
            if (ST1 == null) return null;
            int cols = ST1.GetLength(1);
            double[,] diagram = new double[5, cols];
            for (int i = 0; i < cols; i++)
            {
                diagram[0, i] = ST1[0, i];         // T, °C
                diagram[1, i] = ST1[1, i];         // I_г^0
                diagram[2, i] = ST1[2, i];         // I_в^0
                diagram[3, i] = ST1[5, i];         // I_г(αт) - топка
                diagram[4, i] = ST1[3, i];         // I_зл
            }
            return diagram;
        }

        /// <summary>
        /// Интерполяция энтальпии по температуре из таблицы 6
        /// </summary>
        public static double InterpolateEnthalpyByTemp(double[,] ST1, double temp, int row)
        {
            if (ST1 == null || ST1.GetLength(0) <= 0 || ST1.GetLength(1) < 2) return 0;
            int cols = ST1.GetLength(1);
            int safeRow = Math.Min(row, ST1.GetLength(0) - 1);
            if (safeRow < 0) safeRow = 0;
            if (temp <= ST1[0, 0]) return ST1[safeRow, 0];
            if (temp >= ST1[0, cols - 1]) return ST1[safeRow, cols - 1];
            for (int i = 0; i < cols - 1; i++)
            {
                if (ST1[0, i] <= temp && temp <= ST1[0, i + 1])
                {
                    double denom = ST1[0, i + 1] - ST1[0, i];
                    if (Math.Abs(denom) < 1e-10) return ST1[safeRow, i];
                    double t = (temp - ST1[0, i]) / denom;
                    return ST1[safeRow, i] + (ST1[safeRow, i + 1] - ST1[safeRow, i]) * t;
                }
            }
            return ST1[safeRow, cols - 1];
        }

        public static double CalculateSuperheatEnthalpy(double pressureMPa, double tempC)
        {
            return WaterSteamTables.InterpolateSuperheatedSteam(pressureMPa, tempC).H;
        }

        public static double CalculateFeedWaterEnthalpy(double tempC)
        {
            return WaterSteamTables.InterpolateSaturatedByTemp(tempC).HPrime;
        }

        public static double CalculateSaturatedSteamEnthalpy(double pressureMPa)
        {
            return WaterSteamTables.InterpolateSaturatedByPressure(pressureMPa).HDoublePrime;
        }

        public static double CalculateSaturationTemp(double pressureMPa)
        {
            return WaterSteamTables.InterpolateSaturatedByPressure(pressureMPa).Temp;
        }

        public static void FillCoalParameters(Coal coal, out double Wp, out double Ap, out double Sp,
            out double Cp, out double Hp, out double Np, out double Op, out double Qpn)
        {
            Wp = coal.Wp; Ap = coal.Ap; Sp = coal.SpTotal;
            Cp = coal.Cp; Hp = coal.Hp; Np = coal.Np; Op = coal.Op; Qpn = coal.Qpn;
        }

        public static double CalculateLHV(double Cp, double Hp, double Op, double Sp, double Ap, double Wp)
        {
            return Math.Round((339 * Cp + 1030 * Hp - 109 * (Op - Sp) - 25 * Wp) / 1000, 2);
        }

        public static double CalculateDrumPressure(double superheatPressureMPa)
        {
            return Math.Round(superheatPressureMPa * 1.1 / 0.0980665, 0);
        }

        public static double CalculateFurnaceVolume(double steamCapacity)
        {
            return Math.Round(steamCapacity * 3.8, 0);
        }
    }
}