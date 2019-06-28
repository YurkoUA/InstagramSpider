using InstagramSpider.Common.Models;

namespace InstagramSpider.Common.Interfaces
{
    public interface IFileSaver
    {
        void Save(params FileModel[] files);
    }
}