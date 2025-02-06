using DDD.Domain.Aggregates.ProfileAggregate;
using DDD.Domain.Common;

namespace DDD.Domain.Aggregates.DepartmentAggregate;

public class Department : Entity, IAggregateRoot
{
    /// <summary>
    /// Info of Department
    /// </summary>
    public string Name { get; private set; } = default!;
    public string Code { get; private set; } = default!;
    
    /// <summary>
    /// List profile of department
    /// </summary>
    private readonly List<ProfileDepartment> _profiles = [];

    public IReadOnlyList<ProfileDepartment> Profiles => _profiles;
    
    private Department()
    {
        
    }
    
    private Department(string name, string code)
    {
        Name = name;
        Code = code;
    }

    public static Result<Department> Create(string name, string code)
    {
        var department = new Department(name, code);
        
        return Result.Success(department);
    }
    
    public Result AddMember(Guid profileId)
    {
        var profile = ProfileDepartment.Create(profileId, Id);
        
        // This department already has this profile
        var alreadyExists = _profiles.Any(x => x.ProfileId == profileId);
        if (alreadyExists)
        {
            return profile;
        }
        
        _profiles.Add(profile.Value);
        
        return Result.Success();
    }
}