using System;
using System.Collections.Generic;
using System.Linq;
using Felicity.Domain.Employments.Models;
using Repo = Felicity.Repository.Employment.Entities;

namespace Felicity.Domain.Employments.Mappers;

internal static class EmploymentMapper
{
    public static EmploymentModel ToModel(Repo.EmploymentEntity entity)
    {
        if (entity == null) return null!;

        return new EmploymentModel
        {
            Id = entity.Id,
            Description = entity.JobTitle,
            StartDate = DateTime.SpecifyKind(entity.StartDate, DateTimeKind.Utc),
            EndDate = entity.EndDate.HasValue ? DateTime.SpecifyKind(entity.EndDate.Value, DateTimeKind.Utc) : null
        };
    }

    public static IEnumerable<EmploymentModel> ToModels(IEnumerable<Repo.EmploymentEntity> entities)
        => entities?.Select(ToModel) ?? Enumerable.Empty<EmploymentModel>();

    public static Repo.EmploymentEntity ToEntity(EmploymentPostModel postModel, Guid personId)
    {
        return new Repo.EmploymentEntity
        {
            Id = Guid.NewGuid(),
            JobTitle = postModel.JobTitle,
            StartDate = DateTime.SpecifyKind(postModel.StartDate, DateTimeKind.Utc),
            EndDate = postModel.EndDate.HasValue ? DateTime.SpecifyKind(postModel.EndDate.Value, DateTimeKind.Utc) : null,
            PersonId = personId
        };
    }
}
