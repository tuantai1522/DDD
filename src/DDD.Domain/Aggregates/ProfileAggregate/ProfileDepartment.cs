using DDD.Domain.Common;

namespace DDD.Domain.Aggregates.ProfileAggregate;

public class ProfileDepartment : Entity
{
    public Guid ProfileId { get; private set; }

    public Guid DepartmentId { get; private set; }

    private ProfileDepartment()
    {
        
    }

    private ProfileDepartment(Guid profileId, Guid departmentId)
    {
        ProfileId = profileId;
        DepartmentId = departmentId;
    }

    public static Result<ProfileDepartment> Create(Guid profileId, Guid departmentId)
    {
        var profileDepartment = new ProfileDepartment(profileId, departmentId); 
        
        return Result.Success(profileDepartment);
    }
}