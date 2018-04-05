using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.ObjectModel;

namespace Common.Http
{
    public class HttpPostUploadFile : HttpPost
    {
        private IList<MultiPartField> partFields = new Collection<MultiPartField>();
        private const string PartHeaderPattern = "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n"; //Content-Type: text/plain; charset=US-ASCII\r\nContent-Transfer-Encoding: 8bit\r\n
        private const string FilePartHeaderPattern = "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3};\r\n";//Content-Transfer-Encoding: binary\r\n
        private string boundary;

        // Must use this encoding.
        private const string EncodingName = "iso-8859-1";
        private const string CRLF = "\r\n"; // Line separator in multipart/form-data data post. See RFC 1867


        #region HttpPostUploadFile
        /// <summary>
        /// Initializes a new instance of <see cref="MultiPartHttpPost"/> with the specified <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The uri to identify a resource in the remote server.</param>
        public HttpPostUploadFile(string uri)
            : base(uri)
        {
            boundary = DateTime.Now.Ticks.ToString("x"); // TODO: Random it
            base.ContentType = string.Format(Constants.PostMultiPartContentType, boundary);
        }
        #endregion

        #region PostData
        /// <summary>
        /// Gets the data to post.
        /// </summary>
        public sealed override string PostData
        {
            get
            {
                return ConstructPostBody();
            }
            set
            {
                throw new NotSupportedException("Not supported. Please use PartFields property to convey data to post.");
            }
        }
        #endregion

        #region PostFile
        private string PostFile
        {
            get { return this.ConstructPostFile(); }
        }
        #endregion

        #region PartFields
        /// <summary>
        /// Gets the multi-part fields.
        /// </summary>
        public IList<MultiPartField> PartFields
        {
            get
            {
                return partFields;
            }
        }
        #endregion

        #region ConstructPostBody
        private string ConstructPostBody()
        {
            var postBodyBuilder = new StringBuilder();
            postBodyBuilder.AppendLine();

            foreach (var item in Params)
            {
                postBodyBuilder.AppendLine(string.Format(PartHeaderPattern, boundary, item.Key));
                postBodyBuilder.AppendLine(item.Value);
            }
            return postBodyBuilder.ToString();
        }
        #endregion

        #region ConstructPostFile
        private string ConstructPostFile()
        {
            var postBodyBuilder = new StringBuilder();

            foreach (var field in PartFields)
            {
                postBodyBuilder.AppendLine(string.Format(FilePartHeaderPattern, boundary, field.Name, Path.GetFileName(field.FilePath), GetFileContentType(field.FilePath)));

                var fileData = System.IO.File.ReadAllBytes(field.FilePath);
                field.Value = Encoding.GetEncoding(EncodingName).GetString(fileData);
                postBodyBuilder.AppendLine(field.Value);
            }

            // End tag of muiti-part.
            postBodyBuilder.AppendFormat("--{0}--\r\n", boundary);

            return postBodyBuilder.ToString();
        }
        #endregion

        #region WriteBody
        /// <summary>
        /// See <see cref="HttpPost.WriteBody"/>
        /// </summary>
        protected override void WriteBody(Stream reqStream)
        {
            var postData = PostData;
            if (!string.IsNullOrEmpty(postData))
            {
                var dataBytes = Encoding.UTF8.GetBytes(postData);
                reqStream.Write(dataBytes, 0, dataBytes.Length);
            }

            var postFile = this.PostFile;
            if (!string.IsNullOrEmpty(postFile))
            {
                var dataBytes = Encoding.GetEncoding(EncodingName).GetBytes(postFile);
                reqStream.Write(dataBytes, 0, dataBytes.Length);
            }
        }
        #endregion

        #region GetFileContentType
        private string GetFileContentType(string fileName)
        {
            var contentType = string.Empty;
            var ext = Path.GetExtension(fileName).ToLowerInvariant();
            switch (ext)
            {
                case ".png":
                case ".gif":
                case ".jpeg":
                    contentType = "image/" + ext.Remove(0, 1);
                    break;
                default:
                    contentType = "application/octet-stream";
                    break;
            }

            return contentType;
        }
        #endregion
    }
}
