using FileSignatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Settings
{
    public interface IAllowedFileFormat
    {
        string Extension { get; set; }

        IEnumerable<FileFormat> FileFormat { get; set; }
    }
}
