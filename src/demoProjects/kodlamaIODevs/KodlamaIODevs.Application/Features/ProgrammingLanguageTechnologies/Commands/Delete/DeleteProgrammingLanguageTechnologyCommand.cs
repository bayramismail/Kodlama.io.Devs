using AutoMapper;
using KodlamaIODevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIODevs.Application.Features.ProgrammingLanguageTechnologies.Commands.Delete
{
    public class DeleteProgrammingLanguageTechnologyCommand : IRequest<DeletedProgrammingLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public class DeleteProgrammingLanguageTechnologyCommandHandler : IRequestHandler<DeleteProgrammingLanguageTechnologyCommand, DeletedProgrammingLanguageTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;

            public DeleteProgrammingLanguageTechnologyCommandHandler(IMapper mapper, IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository)
            {
                _mapper = mapper;
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            }

            public async Task<DeletedProgrammingLanguageTechnologyDto> Handle(DeleteProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                var entity = await _programmingLanguageTechnologyRepository.GetAsync(x => x.Id == request.Id);
                var deletedEntity = await _programmingLanguageTechnologyRepository.DeleteAsync(entity);
                var mapper = _mapper.Map<DeletedProgrammingLanguageTechnologyDto>(deletedEntity);
                return mapper;

            }
        }
    }
}
