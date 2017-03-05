using AutoMapper;
using MaiNguyen.GUI.Business.ViewModel;
using MaiNguyen.Entities;
using System.Collections.Generic;
using MaiNguyen.Entities.KhachHang;

namespace MaiNguyen.GUI.Business.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<TestModel, TestViewModel>();
            Mapper.CreateMap<KhachHangModel, KhachHangViewModel>();
        }
    }
}
