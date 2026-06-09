

namespace NDS.Report.DTO
{
    public class NoriCategory
    {

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        public Byte[]? PictureData { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        public string? FileName { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        public string? Mimetype { get; set; }


        /// <summary>
        /// 备  注:类别名称
        /// 默认值:
        ///</summary>
        public string CategoryName { get; set; } = null!;

        /// <summary>
        /// 备  注:顺序号
        /// 默认值:
        ///</summary>
        public int SerialNo { get; set; }


        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        public string Description { get; set; } = null!;

        public string SuggestText { get; set; } = null!;

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        public bool HasPic { get; set; }
        public required List<NoriDetection> Detections { get; set; }
    }
}
