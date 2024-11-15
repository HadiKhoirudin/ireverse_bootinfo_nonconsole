using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iReverse_BootInfo.boot
{
    public class props
    {
        public static void filters(List<string> prop)
        {
            foreach (var item in prop)
            {
                Console.WriteLine(item);
            }

            property(prop: prop, pattern: "brand", logs: "Brand");
            property(prop: prop, pattern: "manufacturer", logs: "OEM");
            property(prop: prop, pattern: "device", logs: "Model");
            property(prop: prop, pattern: "fault", logs: "Name");
            property(prop: prop, pattern: "sdk", logs: "SDK ver");
            property(prop: prop, pattern: "gerprint", logs: "Fingerprint");
        }

        public static void property(List<string> prop, string pattern, string logs)
        {
            bool found = false;
            string tmp = "";
            int counter = 0;
            foreach (var item in prop)
            {
                if (!found)
                {
                    if (item.ToLower().Contains(pattern))
                    {
                        Main.RichLogs($"  {logs} : ", Color.White, false, false);
                        found = true;
                    }
                }
                else 
                { 
                    if (string.IsNullOrEmpty(item) || item == "\n" || item.Length == 1) 
                    { 
                        continue;
                    }
                    else 
                    {
                        if (pattern == "device")
                        {
                            if (item.Substring(0, 1) == "-")
                                Main.RichLogs($"{item.Substring(1, item.Length - 1)}", Color.MediumSlateBlue, true, true);
                            else
                                Main.RichLogs($"{item}", Color.MediumSlateBlue, true, true);

                            found = false;
                        }
                        else if (pattern == "brand")
                        {
                            if (item.ToLower() == "in")
                                Main.RichLogs($"Infinix", Color.MediumSlateBlue, true, true);
                            else if (item.ToLower() == "op")
                                Main.RichLogs($"Oppo", Color.MediumSlateBlue, true, true);
                            else if (item.ToLower() == "vi")
                                Main.RichLogs($"Vivo", Color.MediumSlateBlue, true, true);
                            else if (item.ToLower() == "xi")
                                Main.RichLogs($"Xiaomi", Color.MediumSlateBlue, true, true);

                            found = false;
                        }
                        else if (pattern == "fault")
                        {
                            tmp += item + " ";
                            counter++;
                            if (counter == 2)
                            {
                                Main.RichLogs($"{tmp}", Color.MediumSlateBlue, true, true);
                                found = false;
                            }
                        }
                        else if (pattern == "gerprint")
                        {
                            tmp += item.Replace(Environment.NewLine, "/").Replace("keysp","keys");

                            if (item.Contains("-"))
                            {
                                Main.RichLogs($"{tmp}", Color.MediumSlateBlue, true, true);
                                found = false;
                            }
                        }
                        else 
                        { 
                            Main.RichLogs($"{item}", Color.MediumSlateBlue, true, true);
                            found = false;
                        }
                    }
                }
            }
        }
    }
}
