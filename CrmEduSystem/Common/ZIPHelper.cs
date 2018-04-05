using System;

namespace Common
{
    /// <summary>
    /// winRar压缩解压缩处理类
    /// </summary>
    public class ZIPHelper
    {
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        /// <summary>
        /// 初始化
        /// </summary>
        public ZIPHelper()
        {
            process.StartInfo.FileName = "Winrar.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        }

        #region 压缩
        /// <summary>
        /// 添加文件到压缩文件
        /// </summary>
        /// <param name="pathAndName">文件地址（*.*）</param>
        /// <returns></returns>
        public string Compression(string pathAndName)
        {
            if (string.IsNullOrEmpty(pathAndName)) throw new Exception("被压缩文件地址不能为空!");
            if (pathAndName.IndexOf("-") > -1) throw new Exception("被压缩文件地址不能有符号“-”!");
            var strzipPath = pathAndName;
            try
            {
                strzipPath = strzipPath.Substring(0, pathAndName.LastIndexOf(".")) + ".zip";
                if (System.IO.File.Exists(strzipPath)) System.IO.File.Delete(strzipPath);
                process.StartInfo.Arguments = " a -afzip -ep -o+ -y -ibck " + strzipPath + " " + pathAndName;
                process.Start();
                while (!process.HasExited)
                {
                    System.Threading.Thread.Sleep(100);
                }
                GC.Collect();
            }
            catch
            {
                strzipPath = "";
            }
            return strzipPath;
        }
        /// <summary>
        /// 添加文件到压缩文件
        /// </summary>
        /// <param name="pathAndName">文件地址（*.*）</param>
        /// <param name="strzipPath">输出文件地址（*.*）</param>
        /// <returns></returns>
        public bool Compression(string pathAndName, string strzipPath)
        {
            bool result = false;
            if (string.IsNullOrEmpty(pathAndName)) throw new Exception("被压缩文件地址不能为空!");
            if (pathAndName.IndexOf("-") > -1) throw new Exception("被压缩文件地址不能有符号“-”!");
            if (strzipPath.IndexOf("-") > -1) throw new Exception("输出文件地址不能有符号“-”!");
            if (System.IO.File.Exists(strzipPath)) System.IO.File.Delete(strzipPath);
            process.StartInfo.Arguments = " a -afzip -ep -o+ -y -ibck " + strzipPath + " " + pathAndName;
            process.Start();
            while (!process.HasExited)
            {
                System.Threading.Thread.Sleep(100);
            }
            GC.Collect();
            result = true;
            return result;
        }
        /// <summary>
        /// 添加文件到压缩文件（指定多个文件压缩）
        /// </summary>
        /// <param name="pathAndName">文件地址（*.*）</param>
        /// <param name="strzipPath">输出文件地址（*.*）</param>
        /// <returns></returns>
        public bool Compression(string[] pathAndName, string strzipPath)
        {
            bool result = false;
            foreach (var item in pathAndName)
            {
                if (string.IsNullOrEmpty(item)) throw new Exception("被压缩文件地址不能为空!");
                if (item.IndexOf("-") > -1) throw new Exception("被压缩文件地址不能有符号“-”!");
            }
            if (strzipPath.IndexOf("-") > -1) throw new Exception("输出文件地址不能有符号“-”!");

            if (System.IO.File.Exists(strzipPath)) System.IO.File.Delete(strzipPath);
            string args = " a -afzip -ep -o+ -y -ibck " + strzipPath;
            foreach (var item in pathAndName)
            {
                args += " " + item;
            }
            process.StartInfo.Arguments = args;
            process.Start();
            while (!process.HasExited)
            {
                System.Threading.Thread.Sleep(100);
            }
            GC.Collect();
            result = true;
            return result;
        }
        /// <summary>
        /// 压缩并删除原来文件
        /// </summary>
        /// <param name="pathAndName">文件地址</param>
        /// <returns></returns>
        public string CompressionForDelete(string pathAndName)
        {
            if (string.IsNullOrEmpty(pathAndName)) throw new Exception("被压缩文件地址不能为空!");
            if (pathAndName.IndexOf("-") > -1) throw new Exception("被压缩文件地址不能有符号“-”!");
            var strzipPath = pathAndName;
            try
            {
                if (System.IO.File.Exists(strzipPath)) System.IO.File.Delete(strzipPath);
                strzipPath = strzipPath.Substring(0, pathAndName.LastIndexOf(".")) + ".zip";
                process.StartInfo.Arguments = " m -afzip -ep -y -ibck " + strzipPath + " " + pathAndName;
                process.Start();
                while (!process.HasExited)
                {
                    System.Threading.Thread.Sleep(100);
                }
                GC.Collect();
            }
            catch
            {
                strzipPath = "";
            }
            return strzipPath;
        }
        /// <summary>
        /// 压缩并删除原来文件
        /// </summary>
        /// <param name="pathAndName">文件地址</param>
        /// <param name="strzipPath">zip文件地址</param>
        /// <returns></returns>
        public bool CompressionForDelete(string pathAndName, string strzipPath)
        {
            bool result = false;
            if (string.IsNullOrEmpty(pathAndName)) throw new Exception("被压缩文件地址不能为空!");
            if (pathAndName.IndexOf("-") > -1) throw new Exception("被压缩文件地址不能有符号“-”!");

            if (string.IsNullOrEmpty(strzipPath))
            {
                strzipPath = strzipPath.Substring(0, pathAndName.LastIndexOf(".")) + ".zip";
            }
            if (System.IO.File.Exists(strzipPath)) System.IO.File.Delete(strzipPath);
            process.StartInfo.Arguments = " m -afzip -ep -y -ibck " + strzipPath + " " + pathAndName;
            process.Start();
            while (!process.HasExited)
            {
                System.Threading.Thread.Sleep(100);
            }
            GC.Collect();
            result = true;
            return result;
        }
        /// <summary>
        /// 压缩文件、目录（若选择删除，则路迳只能是文件）
        /// </summary>
        /// <param name="path">文件、目录地址</param>
        /// <param name="targetPath">指定的输出压缩文件地址</param>
        /// <param name="password"></param>
        /// <param name="isDelete">仅对文件</param>
        /// <returns></returns>
        public bool Compression(string path, string targetPath, string password, bool? isDelete)
        {
            bool result = false;
            if (string.IsNullOrEmpty(path)) throw new Exception("被压缩文件或目录地址不能为空!");
            string args = " a -afzip -ed -y -r -ep1 -ibck ";
            if (isDelete != null && isDelete == true)
            {
                args = " m -afzip -ed -y -r -ep1 -ibck ";
            }
            if (!string.IsNullOrEmpty(password))
            {
                args += " -p" + password + " ";
            }
            if (string.IsNullOrEmpty(targetPath))
            {
                if (path.Substring(path.Length - 1, 1) == @"\")
                {
                    targetPath = path + (DateTime.Now.Millisecond + (new Random(DateTime.Now.Millisecond).Next(999, 999999))) + ".zip";
                }
                else
                {
                    targetPath = path.Substring(0, path.LastIndexOf(".")) + ".zip";
                }
            }
            if (System.IO.File.Exists(targetPath)) System.IO.File.Delete(targetPath);
            process.StartInfo.Arguments = args + targetPath + " " + path;
            process.Start();
            while (!process.HasExited)
            {
                System.Threading.Thread.Sleep(100);
            }
            GC.Collect();
            result = true;
            return result;
        }

        #endregion


        #region 解压缩
        /// <summary>
        /// 解压缩单个文件
        /// </summary>
        /// <param name="pathAndName">zip文件地址</param>
        /// <returns></returns>
        public string Decompression(string pathAndName)
        {
            if (string.IsNullOrEmpty(pathAndName)) throw new Exception("解压缩文件地址不能为空!");
            string targetPath = pathAndName.Substring(0, pathAndName.LastIndexOf("\\") + 1);
            try
            {
                process.StartInfo.Arguments = " x -o+ -y " + pathAndName + " " + targetPath;
                process.Start();
                while (!process.HasExited)
                {
                    System.Threading.Thread.Sleep(100);
                }
                GC.Collect();
            }
            catch
            {
                targetPath = "";
            }
            return targetPath;
        }

        /// <summary>
        /// 解压缩加密码文件
        /// </summary>
        /// <param name="pathAndName">zip文件地址</param>
        /// <param name="targetPath">解压到指定目录（不指定为当前目录）</param>
        /// <param name="password">可以为空</param>
        /// <returns></returns>
        public bool Decompression(string pathAndName, string targetPath, string password)
        {
            bool result = false;
            try
            {
                string args = "";
                if (string.IsNullOrEmpty(pathAndName)) throw new Exception("解压缩文件或目录地址不能为空!");
                if (string.IsNullOrEmpty(targetPath))
                {
                    args = " e -o+ -y " + pathAndName;
                }
                else
                {
                    args = " x -o+ -y " + pathAndName + " " + targetPath;
                }
                if (!string.IsNullOrEmpty(password))
                {
                    args += " -p" + password;
                }
                else
                {
                    args += " -p-";
                }
                process.StartInfo.Arguments = args;
                process.Start();
                while (!process.HasExited)
                {
                    System.Threading.Thread.Sleep(100);
                }
                GC.Collect();
                result = true;
            }
            catch { }
            return result;
        }
        #endregion
    }
}
