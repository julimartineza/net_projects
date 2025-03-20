using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.Backend.Domain.Trees.Entities;
using UCR.ECCI.PI.Backend.Presentation.Trees.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Trees.Mappers;

[Mapper]
internal static partial class TreeMapper
{
    internal static partial TreeDto ToDto(this Tree entity);
    internal static partial Tree ToEntity(this TreeDto dto);
}
