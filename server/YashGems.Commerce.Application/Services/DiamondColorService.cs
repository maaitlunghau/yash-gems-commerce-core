using AutoMapper;
using YashGems.Commerce.Application.DTOs;
using YashGems.Commerce.Application.Interfaces;
using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;

namespace YashGems.Commerce.Application.Services
{
    public class DiamondColorService : IDiamondColorService
    {
        private readonly IDiamondColorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DiamondColorService(IDiamondColorRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DiamondColorDto>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DiamondColorDto>>(data);
        }

        public async Task<DiamondColorDto?> GetByIdAsync(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            return _mapper.Map<DiamondColorDto>(data);
        }

        public async Task CreateAsync(DiamondColorDto dto)
        {
            var entity = _mapper.Map<DiamondColor>(dto);
            await _repository.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, DiamondColorDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                _mapper.Map(dto, entity);
                _repository.Update(entity);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            _repository.Delete(entity);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
