using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _ImageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _ImageFileDal = imageFileDal;
        }

        public List<ImageFile> GetList()
        {
             return _ImageFileDal.List();
        }
        public ImageFile GetByIdImageFile(int id)
        {
            return _ImageFileDal.GetByID(x => x.ImageID== id);
        }
        public void ImageAdd(ImageFile imageFile)
        {
            _ImageFileDal.Insert(imageFile);
        }

        public void ImageDelete(ImageFile imageFile)
        {
            _ImageFileDal.Delete(imageFile);
        }

        public void ImageUpdate(ImageFile imageFile)
        {
            _ImageFileDal.Update(imageFile);
        }
    }
}
