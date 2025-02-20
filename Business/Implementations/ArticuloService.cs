using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Data.UnitOfWork;
using Entities;
using Microsoft.AspNetCore.Hosting;

namespace Business.Implementations
{
    public class ArticuloService: IArticuloService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IResourceService _resourceService;
        IWebHostEnvironment _hostingEnvironment;
        public ArticuloService(IUnitOfWork unitOfWork,IMapper mapper, IResourceService resourceService,IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _resourceService = resourceService;
            _hostingEnvironment = webHostEnvironment;
        }

        public async Task<IEnumerable<ArticuloDTO>> ObtenerTodos()
        {
            return _mapper.Map<IEnumerable<ArticuloDTO>>(await _unitOfWork.Articulos.GetAll($"{nameof(Articulo.Imagen)}"));
        }

        public async Task<ArticuloDTO?> ObtenerPorId(int id)
        {
            return _mapper.Map<ArticuloDTO>(await _unitOfWork.Articulos.GetById(id, $"{nameof(Articulo.Imagen)}"));
        }

        public async Task<ArticuloDTO> Agregar(ArticuloRequestDTO articulo, ResourceRequest? imagen)
        {
            Articulo nuevo = _mapper.Map<Articulo>(articulo);

            if(imagen is not null)
            {
                imagen.FolderPath = $"{_hostingEnvironment.EnvironmentName}/articulos";
                imagen.FileName = $"{Guid.NewGuid().ToString()}_{DateTime.UtcNow.ToString("dd_mm_yyyy")}";
                Resource resource = await _resourceService.UploadFile(imagen);
                nuevo.Imagen = resource;
            }

            await _unitOfWork.Articulos.Add(nuevo);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ArticuloDTO>(nuevo);
        }

        public async Task Actualizar(int id, ArticuloRequestDTO articulo, ResourceRequest? imagen)
        {
            Articulo? actualizar = await _unitOfWork.Articulos.GetById(id,$"{nameof(Articulo.Imagen)}");
            if (actualizar != null)
            {
                if(imagen is not null)
                {
                    if(actualizar.Imagen is not null)
                    {
                        await _resourceService.DeleteFile(actualizar.Imagen.Path, actualizar.Imagen.Name, actualizar.Imagen.Extension);
                        _unitOfWork.Resources.Delete(actualizar.Imagen);
                    }

                    imagen.FolderPath = $"{_hostingEnvironment.EnvironmentName}/articulos";
                    imagen.FileName = $"{Guid.NewGuid().ToString()}_{DateTime.UtcNow.ToString("dd_mm_yyyy")}";
                    Resource resource = await _resourceService.UploadFile(imagen);
                    actualizar.Imagen = resource;
                }
                _mapper.Map(articulo, actualizar);
                _unitOfWork.Articulos.Update(actualizar);
                await _unitOfWork.SaveChangesAsync();
            }        
        }

        public async Task Eliminar(int id)
        {
            Articulo? articulo = await _unitOfWork.Articulos.GetById(id, $"{nameof(Articulo.Imagen)}");
            if (articulo != null)
            {
                if (articulo.Imagen is not null)
                {
                    await _resourceService.DeleteFile(articulo.Imagen.Path, articulo.Imagen.Name, articulo.Imagen.Extension);
                    _unitOfWork.Resources.Delete(articulo.Imagen);
                }
                _unitOfWork.Articulos.Delete(articulo);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<ResourceResponseArticle> GetImagen(int id)
        {
            ResourceResponseArticle response = new ResourceResponseArticle();
            Resource? resource = await _unitOfWork.Resources.GetById(id);

            if (resource != null)
            {
                response.Stream = await _resourceService.DownloadFile(resource.Path, resource.Name, resource.Extension);
                response.ContentType = resource.ContentType;
            }
            return response;
        }
    }

}
