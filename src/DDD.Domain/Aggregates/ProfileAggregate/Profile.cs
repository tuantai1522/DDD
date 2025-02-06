using DDD.Domain.Aggregates.GenderAggregate;
using DDD.Domain.Common;

namespace DDD.Domain.Aggregates.ProfileAggregate;

public class Profile : Entity, IAggregateRoot
{
    /// <summary>
    /// Info of Profile
    /// </summary>
    public string FirstName { get; private set; } = default!;
    public string MiddleName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    
    /// <summary>
    /// Gender of Profile
    /// </summary>
    public Guid? GenderId { get; private set; }
    
    public Gender? Gender { get; private set; }

    /// <summary>
    /// List department of profile
    /// </summary>
    private readonly List<ProfileDepartment> _departments = [];

    public IReadOnlyList<ProfileDepartment> Departments => _departments;

    private Profile()
    {
        
    }
    
    private Profile(string firstName, string middleName, string lastName)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
    }

    public static Result<Profile> Create(string firstName, string middleName, string lastName)
    {
        var profile = new Profile(firstName, middleName, lastName);
        
        return Result.Success(profile);
    }
    
    public void SetGender(Guid genderId) => GenderId = genderId;

    public Result JoinDepartment(Guid departmentId)
    {
        var profileDepartment = ProfileDepartment.Create(Id, departmentId);
        
        // This profile already joins this department
        var alreadyExists = _departments.Any(x => x.DepartmentId == departmentId);
        if (alreadyExists)
        {
            return profileDepartment;
        }
        
        _departments.Add(profileDepartment.Value);
        
        return Result.Success();
    }
}