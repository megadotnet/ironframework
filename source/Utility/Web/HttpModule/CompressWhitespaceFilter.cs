// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompressWhitespaceFilter.cs" company="Megadotnet">
//    Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   CompressWhitespaceFilter
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace IronFramework.Utility.Web.HttpModule
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// CompressWhitespaceFilter
    /// </summary>
    public class CompressWhitespaceFilter : Stream
    {
        /// <summary>
        /// The _content g zip stream.
        /// </summary>
        private readonly GZipStream _contentGZipStream;

        /// <summary>
        /// The _content stream.
        /// </summary>
        private readonly Stream _contentStream;

        /// <summary>
        /// The _content_ deflate stream.
        /// </summary>
        private readonly DeflateStream _content_DeflateStream;

        /// <summary>
        /// The _compress options.
        /// </summary>
        private CompressOptions _compressOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompressWhitespaceFilter"/> class.
        /// </summary>
        /// <param name="contentStream">
        /// The content stream.
        /// </param>
        /// <param name="compressOptions">
        /// The compress options.
        /// </param>
        public CompressWhitespaceFilter(Stream contentStream, CompressOptions compressOptions)
        {
            if (compressOptions == CompressOptions.GZip)
            {
                _contentGZipStream = new GZipStream(contentStream, CompressionMode.Compress);
                _contentStream = _contentGZipStream;
            }
            else if (compressOptions == CompressOptions.Deflate)
            {
                _content_DeflateStream = new DeflateStream(contentStream, CompressionMode.Compress);
                _contentStream = _content_DeflateStream;
            }
            else
            {
                _contentStream = contentStream;
            }

            _compressOptions = compressOptions;
        }

        /// <summary>
        /// Gets a value indicating whether CanRead.
        /// </summary>
        public override bool CanRead
        {
            get { return _contentStream.CanRead; }
        }

        /// <summary>
        /// Gets a value indicating whether CanSeek.
        /// </summary>
        public override bool CanSeek
        {
            get { return _contentStream.CanSeek; }
        }

        /// <summary>
        /// Gets a value indicating whether CanWrite.
        /// </summary>
        public override bool CanWrite
        {
            get { return _contentStream.CanWrite; }
        }

        /// <summary>
        /// Gets Length.
        /// </summary>
        public override long Length
        {
            get { return _contentStream.Length; }
        }

        /// <summary>
        /// Gets or sets Position.
        /// </summary>
        public override long Position
        {
            get { return _contentStream.Position; }
            set { _contentStream.Position = value; }
        }

        /// <summary>
        /// The flush.
        /// </summary>
        public override void Flush()
        {
            _contentStream.Flush();
        }

        /// <summary>
        /// The read.
        /// </summary>
        /// <param name="buffer">
        /// The buffer.
        /// </param>
        /// <param name="offset">
        /// The offset.
        /// </param>
        /// <param name="count">
        /// The count.
        /// </param>
        /// <returns>
        /// The read.
        /// </returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            return _contentStream.Read(buffer, offset, count);
        }

        /// <summary>
        /// The seek.
        /// </summary>
        /// <param name="offset">
        /// The offset.
        /// </param>
        /// <param name="origin">
        /// The origin.
        /// </param>
        /// <returns>
        /// The seek.
        /// </returns>
        public override long Seek(long offset, SeekOrigin origin)
        {
            return _contentStream.Seek(offset, origin);
        }

        /// <summary>
        /// The set length.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public override void SetLength(long value)
        {
            _contentStream.SetLength(value);
        }

        /// <summary>
        /// The write.
        /// </summary>
        /// <param name="buffer">
        /// The buffer.
        /// </param>
        /// <param name="offset">
        /// The offset.
        /// </param>
        /// <param name="count">
        /// The count.
        /// </param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            var data = new byte[count + 1];
            Buffer.BlockCopy(buffer, offset, data, 0, count);

            string strtext = Encoding.UTF8.GetString(data);
            strtext = Regex.Replace(strtext, "^\\s*", string.Empty, RegexOptions.Compiled | RegexOptions.Multiline);
            strtext = Regex.Replace(strtext, "\\r\\n", string.Empty, RegexOptions.Compiled | RegexOptions.Multiline);
            strtext = Regex.Replace(strtext, "<!--*.*?-->", string.Empty, RegexOptions.Compiled | RegexOptions.Multiline);

            byte[] outdata = Encoding.UTF8.GetBytes(strtext);
            _contentStream.Write(outdata, 0, outdata.GetLength(0));
        }
    }
}