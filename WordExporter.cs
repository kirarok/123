using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using BoilerCalc;
using System;
using System.IO;
using System.Windows.Forms;

public static class WordExporter
{
    public static bool ExportToWord(string templatePath)
    {
        var sfd = new SaveFileDialog
        {
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            Filter = "Word (*.docx)|*.docx",
            FileName = "Расчет " + Global.BoilerName + ".docx"
        };
        if (sfd.ShowDialog() != DialogResult.OK) return false;
        try
        {
            CreateDoc(sfd.FileName);
            MessageBox.Show("Файл сохранён:\n" + sfd.FileName);
            return true;
        }
        catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); return false; }
    }

    static void CreateDoc(string path)
    {
        string cp = null;
        using (var d = WordprocessingDocument.Create(path, WordprocessingDocumentType.Document))
        {
            var mp = d.AddMainDocumentPart(); mp.Document = new Document();
            var b = mp.Document.AppendChild(new Body());
            Action<string> L = s => b.Append(P(s, false, 20));
            Action<string, bool, int> H = (s, bld, sz) => b.Append(P(s, bld, sz));

            // Титул
            H("", true, 48); H("Поверочный тепловой расчет котла", true, 32);
            H(Global.BoilerName, false, 28); H("", false, 16);
            H("Расчет произвел:  " + Global.FIO, false, 24);
            H("", false, 16); H("1. Исходные данные", true, 28);

            // Табл.1 котёл
            H("Котлоагрегат: " + Global.BoilerName, false, 22);
            b.Append(T2H(new[,]{{"Параметр","Значение"},{"Модель",Global.BoilerName},
                {"Паропроизводительность",Global.QBoiler+" т/ч"},{"Давление в барабане",Global.PBaraban+" кгс/см\u00B2"},
                {"Давление перегретого пара",Global.PPar+" кгс/см\u00B2"},{"Температура перегретого пара",Global.TPar+" \u00B0C"},
                {"Температура питательной воды",Global.TPitV+" \u00B0C"},{"Объем топочной камеры",Global.VTop+" м\u00B3"}}));

            // Табл.2 уголь
            H("Топливо: " + Global.FuelBrend + ", Марка: " + Global.Marka, false, 22);
            b.Append(T2H(new[,]{{"Компонент","Значение"},{"W"+"Р",Global.WР+" %"},
                {"A"+"Р",Global.АР+" %"},{"S"+"Р",Global.SР+" %"},{"C"+"Р",Global.СР+" %"},
                {"H"+"Р",Global.НР+" %"},{"N"+"Р",Global.NР+" %"},{"O"+"Р",Global.ОР+" %"},
                {"Qpн (МДж/кг)",Global.QРh+" МДж/кг"},{"Qpн (кДж/кг)",Global.KiloDJ+" кДж/кг"},
                {"Qpн (ккал/кг)",Global.KiloKal+" ккал/кг"}}));

            // Табл.3 топка
            H("Параметры топки:", false, 22);
            b.Append(T2H(new[,]{{"Параметр","Значение"},{"\u03B1т",Global.aT.ToString("F2")},{"q3",Global.q3+" %"},
                {"q4",Global.q4+" %"},{"aун",Global.aYN.ToString("F2")},{"\u0394\u03B1пп",Global.DaPP.ToString("F2")},
                {"\u0394\u03B1вэ",Global.DaVE.ToString("F2")},{"\u0394\u03B1вп",Global.DaVP.ToString("F2")},
                {"\u0394\u03B1т",Global.DaT.ToString("F2")},{"\u0394\u03B1пл",Global.DaPL.ToString("F2")}}));

            // Табл.4 зола
            H("Химсостав золы:", false, 22);
            b.Append(T2H(new[,]{{"Компонент","Значение"},{"SiO\u2082",Global.SiO2+" %"},{"Al\u2082O\u2083",Global.Al2O3+" %"},
                {"TiO\u2082",Global.TiO2+" %"},{"Fe\u2082O\u2083",Global.Fe2O3+" %"},{"CaO",Global.CaO+" %"},
                {"MgO",Global.MgO+" %"},{"K\u2082O",Global.K2O+" %"},{"Na\u2082O",Global.Na2O+" %"}}));

            // Объёмы
            H("", false, 16); H("2. Объёмы воздуха и продуктов сгорания", true, 28);
            L("Vв\u2070 = " + Global.TerOB + " м\u00B3/кг"); L("VRO\u2082\u2070 = " + Global.TerORO2 + " м\u00B3/кг");
            L("VN\u2082\u2070 = " + Global.TerON2 + " м\u00B3/кг"); L("VH\u2082O\u2070 = " + Global.TerOH2O + " м\u00B3/кг");
            L("Vг\u2070 = " + Global.TerOr + " м\u00B3/кг");

            // Таблицы 5-7
            H("", false, 16); H("3. Таблица 5 - Объёмы газов по газоходам", true, 24);
            if (Global.Tabl5 != null) b.Append(MakeT5());
            H("", false, 16); H("4. Таблица 6 - Энтальпии продуктов сгорания", true, 24);
            if (Global.ST1 != null) b.Append(MakeT6());
            H("", false, 16); H("5. Таблица 7 - Тепловой баланс", true, 24);
            if (Global.Tabl7 != null) b.Append(MakeT7());

            // Конвективные
            H("", false, 16); H("6. Расчёт конвективных поверхностей", true, 24);
            if (Global.Tabl8 != null) { H("6.1 ВЗП", true, 22); b.Append(MakeT810(Global.Tabl8, true)); }
            if (Global.Tabl9 != null) { H("6.2 ВЭК", true, 22); b.Append(MakeT810(Global.Tabl9, false)); }
            if (Global.Tabl10 != null) { H("6.3 КПП", true, 22); b.Append(MakeT810(Global.Tabl10, false)); }

            // I-Q диаграмма
            if (Global.IThetaDiagram != null)
            {
                cp = Path.Combine(Path.GetTempPath(), "ith_" + Guid.NewGuid() + ".png");
                ChartGenerator.CreateIThetaDiagram(Global.IThetaDiagram, cp);
                if (File.Exists(cp))
                {
                    H("", false, 16); H("7. I-\u03B8 диаграмма продуктов сгорания", true, 24);
                    var ip = mp.AddImagePart(ImagePartType.Png);
                    using (var fs = new FileStream(cp, FileMode.Open)) ip.FeedData(fs);
                    string rid = mp.GetIdOfPart(ip);
                    b.Append(new Paragraph(new Run(new Drawing(
                        new DocumentFormat.OpenXml.Drawing.Wordprocessing.Inline(
                            new DocumentFormat.OpenXml.Drawing.Wordprocessing.Extent { Cx = 800000, Cy = 600000 },
                            new DocumentFormat.OpenXml.Drawing.Wordprocessing.EffectExtent(),
                            new DocumentFormat.OpenXml.Drawing.Wordprocessing.DocProperties { Id = 1, Name = "ITheta" },
                            new DocumentFormat.OpenXml.Drawing.Graphic(
                                new DocumentFormat.OpenXml.Drawing.GraphicData(
                                    new DocumentFormat.OpenXml.Drawing.Pictures.Picture(
                                        new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(
                                            new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties { Id = 0, Name = "ith" },
                                            new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties()),
                                        new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(
                                            new DocumentFormat.OpenXml.Drawing.Blip { Embed = rid },
                                            new DocumentFormat.OpenXml.Drawing.Stretch(new DocumentFormat.OpenXml.Drawing.FillRectangle())),
                                        new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties(
                                            new DocumentFormat.OpenXml.Drawing.Transform2D(
                                                new DocumentFormat.OpenXml.Drawing.Offset(),
                                                new DocumentFormat.OpenXml.Drawing.Extents { Cx = 800000, Cy = 600000 }),
                                            new DocumentFormat.OpenXml.Drawing.PresetGeometry { Preset = DocumentFormat.OpenXml.Drawing.ShapeTypeValues.Rectangle }))
                                ) { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })))))));
                }
            }
            mp.Document.Save();
        }
        if (cp != null) try { File.Delete(cp); } catch { }
    }

    static string HtmlEncode(string s) => s;

    static Paragraph P(string t, bool bld, int sz)
    {
        var rp = new RunProperties { FontSize = new FontSize { Val = (sz*2).ToString() }, FontSizeComplexScript = new FontSizeComplexScript { Val = (sz*2).ToString() } };
        if (bld) rp.Bold = new Bold();
        return new Paragraph(new Run(new Text(t ?? "")) { RunProperties = rp });
    }

    static DocumentFormat.OpenXml.Wordprocessing.TableCell C(string t, bool bld)
    {
        var rp = new RunProperties { FontSize = new FontSize { Val = "20" }, FontSizeComplexScript = new FontSizeComplexScript { Val = "20" } };
        if (bld) rp.Bold = new Bold();
        return new DocumentFormat.OpenXml.Wordprocessing.TableCell(new Paragraph(new Run(new Text(t ?? "")) { RunProperties = rp }));
    }

    static Table T2H(string[,] data)
    {
        var t = new Table();
        int rows = data.GetLength(0), cols = data.GetLength(1);
        for (int i = 0; i < rows; i++) { var tr = new TableRow();
            for (int j = 0; j < cols; j++) tr.Append(C(data[i, j], i == 0)); t.Append(tr); }
        return t;
    }

    static Table MakeT5()
    {
        var d = Global.Tabl5; int c = d.GetLength(1); var t = new Table();
        var hr = new TableRow(); hr.Append(C("Параметр", true));
        string[] gh = {"Топка","КПП I","КПП II","ВЭК II","ВЗП II","ВЭК I","ВЗП I","Дымосос"};
        for (int j = 0; j < c && j < gh.Length; j++) hr.Append(C(gh[j], true)); t.Append(hr);
        string[] rn = {"\u03B1''","\u03B1ср","VH\u2082O","Vг","rRO\u2082","rH\u2082O","rп","\u03BCзл","Gг"};
        for (int i = 0; i < 9 && i < d.GetLength(0); i++) { var r = new TableRow(); r.Append(C(rn[i], false));
            for (int j = 0; j < c; j++) r.Append(C(d[i,j].ToString("F4"), false)); t.Append(r); }
        return t;
    }

    static Table MakeT6()
    {
        var d = Global.ST1; int c = d.GetLength(1); var t = new Table();
        var hr = new TableRow(); hr.Append(C("T\u00B0C", true));
        string[] eh = {"Iг\u2070","Iв\u2070","Iзл","Топка","КПП I","КПП II","ВЭК II","ВЗП II","ВЭК I","ВЗП I","Дим"};
        for (int i = 0; i < 11 && i < d.GetLength(0); i++) hr.Append(C(i < eh.Length ? eh[i] : "", true)); t.Append(hr);
        for (int col = 0; col < c; col++) { var r = new TableRow(); r.Append(C(d[0,col].ToString("F0"), false));
            for (int row = 1; row < Math.Min(12, d.GetLength(0)); row++) r.Append(C(d[row,col].ToString("F0"), false)); t.Append(r); }
        return t;
    }

    static Table MakeT7()
    {
        var d = Global.Tabl7;
        return T2H(new[,]{{"Параметр","Обозн.","Значение"},
            {"Qpн (кДж/кг)","Qpp",d[0]+""},{"Qpн (ккал/кг)","Qpн(ккал)",d[1]+""},
            {"q3 - хим.%","q3",d[2]+""},{"q4 - мех.%","q4",d[3]+""},{"q5 - окр.%","q5",d[4]+""},
            {"q6 - шлак%","q6",d[5]+""},{"tух.\u00B0C","\u03B8ух",d[6]+""},{"Iух кДж/кг","Iух",d[7]+""},
            {"tхв \u00B0C","tхв",d[8]+""},{"Iхв0 кДж/кг","Iхв0",d[9]+""},{"\u03B1шл","aшл",d[11]+""},
            {"q2 - ух.%","q2",d[14]+""},{"\u03B7ка бр%","\u03B7",d[15]+""},{"Qка кДж/с","Qка",d[16]+""},
            {"B кг/с","B",d[17]+""},{"B кг/ч","Bч",d[18]+""},{"Bр кг/с","Bр",d[19]+""},
            {"Bр кг/ч","Bрч",d[20]+""},{"\u03C6","\u03C6",d[21]+""}});
    }

    static Table MakeT810(double[,] dt, bool isVZP)
    {
        var t = new Table();
        t.Append(new TableRow(C("Параметр",true),C("Обозн.",true),C("Значение",true)));
        t.Append(Row("d, мм","d",dt[0,0].ToString("F0")));
        t.Append(Row("S1/S2, мм","S1/S2",$"{dt[1,0]:F0}/{dt[1,1]:F0}"));
        t.Append(Row("\u03C31","s1",dt[2,0].ToString("F2")));
        t.Append(Row("\u03C32","s2",dt[3,0].ToString("F2")));
        t.Append(Row("Z2","Z2",dt[4,0].ToString("F0")));
        if (isVZP) {
            t.Append(Row("fв, м\u00B2","fв",dt[5,0].ToString("F2")));
            t.Append(Row("Fг, м\u00B2","Fг",dt[6,0].ToString("F2")));
            t.Append(Row("n1/n2","n",$"{dt[7,0]:F0}/{dt[7,1]:F0}"));
            t.Append(Row("\u03B8ух'', \u00B0C","\u03B8ух''",dt[8,0].ToString("F0")));
            t.Append(Row("Iух''","Iух''",dt[9,0].ToString("F0")));
            t.Append(Row("\u03B8' \u00B0C","\u03B8'",dt[10,0].ToString("F0")));
            t.Append(Row("I' кДж/кг","I'",dt[11,0].ToString("F0")));
            t.Append(Row("Qб","Qб",dt[12,0].ToString("F1")));
            t.Append(Row("\u0394t \u00B0C","\u0394t",dt[13,0].ToString("F0")));
            t.Append(Row("H м\u00B2","H",dt[14,0].ToString("F0")));
        } else {
            t.Append(Row("\u03B8' вх \u00B0C","\u03B8'",dt[5,0].ToString("F0")));
            t.Append(Row("\u03B8'' вых \u00B0C","\u03B8''",dt[6,0].ToString("F0")));
            t.Append(Row("Qб","Qб",dt[7,0].ToString("F1")));
            t.Append(Row("\u0394t \u00B0C","\u0394t",dt[8,0].ToString("F0")));
            t.Append(Row("H м\u00B2","H",dt[9,0].ToString("F0")));
            t.Append(Row("tср \u00B0C","tср",dt[10,0].ToString("F0")));
            t.Append(Row("w м/с","w",dt[11,0].ToString("F1")));
        }
        return t;
    }
    static TableRow Row(string a, string b, string v)
    {
        var tr = new TableRow();
        tr.Append(C(a, false));
        tr.Append(C(b, false));
        tr.Append(C(v, false));
        return tr;
    }
}