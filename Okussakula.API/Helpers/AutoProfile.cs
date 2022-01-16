using AutoMapper;
using Okussakula.Model.Data;
using Okussakula.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkussakulaAPI
{
    public class AutoProfile:Profile
    {
        public AutoProfile()
        {
            CreateMap<Administrator, AdministradorCreatDTO>().ReverseMap();
            CreateMap<Administrator, AdministradorListDTO>().ReverseMap();
            CreateMap<Administrator, AdministradorLoginDTO>().ReverseMap();
            CreateMap<Administrator, AdministradorPerfilDTO>().ReverseMap();

            CreateMap<Instituition, InstituitionCreatDTO>().ReverseMap();
            CreateMap<Instituition, InstituitionListDTO>().ReverseMap();
            CreateMap<Instituition, InstituitionListAnyDTO>().ReverseMap();

            CreateMap<User, UserCreatDTO>().ReverseMap();
            CreateMap<User, UserAuxiliarListlDTO>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<User, UserPerfilDTO>().ReverseMap();

            CreateMap<CronogramConsult, ConsultCronogramCreatDTO>().ReverseMap();
            CreateMap<CronogramConsult, ConsultCronogramDTO>().ReverseMap();
            CreateMap<CronogramConsult, ConsultCronogramConsultDTO>().ReverseMap();
            
            CreateMap<ConsultHorario, ConsultHorarioListDTO>().ReverseMap();
            CreateMap<ConsultHorario, ConsultHorarioListConsultDTO>().ReverseMap();

            CreateMap<Consult, ConsultCreatDTO>().ReverseMap();
            CreateMap<Consult, ConsultListDTO>().ReverseMap();
            CreateMap<Consult, ConsultListConsultsDTO>().ReverseMap();

            CreateMap<CronogramExam, CronogramExamCreatDTO>().ReverseMap();
            CreateMap<CronogramExam, CronogramExamDTO>().ReverseMap();



            CreateMap<Speciality, SpecialityCreatDTO>().ReverseMap();
            CreateMap<Speciality, SpecialityDTO>().ReverseMap();

            CreateMap<Exam, ExamCreatDTO>().ReverseMap();
            CreateMap<Exam, ExamDTO>().ReverseMap();

            CreateMap<InstituitionSpeciality, InstituitionSpecialityCreatDTO>().ReverseMap();
            CreateMap<InstituitionSpeciality, InstituitionSpecialityDTO>().ReverseMap();
            CreateMap<InstituitionSpeciality, InstituitionSpecialityPrecoDTO>().ReverseMap();
            CreateMap<InstituitionSpeciality, InstituitionSpecialityConsultDTO>().ReverseMap();

            CreateMap<InstituitionExam, InstituitionExamCreatDTO>().ReverseMap();
            CreateMap<InstituitionExam, InstituitionExamDTO>().ReverseMap();
        }
    }
}
