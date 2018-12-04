using FMBPublic.Model;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FMBPublic.Services
{
    static public class Connection
    {


      static  public ConnectionSetting GetCs(string Db=null)
        {
            try
            {
                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot",
                            "CS.json");

                if (System.IO.File.Exists(path))
                {
                    var json = System.IO.File.ReadAllText(path);
                    var Conn = JsonConvert.DeserializeObject<ConnectionSetting>(json);
                    if (!string.IsNullOrEmpty(Db))
                        Conn.DataBase = Db;
                    return Conn;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        static public ConnectionSetting GetWebInfoCs()
        {
            try
            {
                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot",
                            "webinfo.json");

                if (System.IO.File.Exists(path))
                {
                    var json = System.IO.File.ReadAllText(path);
                    var Conn = JsonConvert.DeserializeObject<ConnectionSetting>(json);
                    return Conn;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        static public ConnectionSetting GetZymasterCs()
        {
            try
            {
                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot",
                            "zymaster.json");

                if (System.IO.File.Exists(path))
                {
                    var json = System.IO.File.ReadAllText(path);
                    var Conn = JsonConvert.DeserializeObject<ConnectionSetting>(json);
                    return Conn;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
