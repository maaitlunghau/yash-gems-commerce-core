using AutoMapper;
using YashGems.Commerce.Application.DTOs;
using YashGems.Commerce.Application.Interfaces;
using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;

namespace YashGems.Commerce.Application.Services
{
    public class DiamondCutService : IDiamondCutService
    {
        private readonly IDiamondCutRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DiamondCutService(IDiamondCutRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DiamondCutDto>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DiamondCutDto>>(data);
        }

        public async Task<DiamondCutDto?> GetByIdAsync(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            return _mapper.Map<DiamondCutDto>(data);
        }

        public async Task CreateAsync(DiamondCutDto dto)
        {
            var entity = _mapper.Map<DiamondCut>(dto);
            await _repository.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, DiamondCutDto dto)
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
