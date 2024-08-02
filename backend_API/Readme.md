# first branch of admin dashboard
-  API Endpoints: Use the /api/ServiceRecords/due endpoint to fetch due vehicles and the /api/ServiceRecords/assign endpoint to assign service advisors.
UI Integration: Ensure the Admin Dashboard can interact with these API endpoints.


# this update for 2nd branch of admin dashboard
3. Update the Admin Dashboard UI
- Ensure your Admin Dashboard can:

- View Vehicles Under Service: Make a call to the /api/ServiceRecords/under-service endpoint to fetch and display vehicles currently under service.

- View Service Details: Make a call to the /api/ServiceRecords/details/{id} endpoint to fetch details for a specific service record and display them.

- Update Service Status: Provide a UI to update the service status by making a PUT request to the /api/ServiceRecords/update-status/{id} endpoint.

# this update for 3rd branch of admin dashboard
 Update the Admin Dashboard UI
- Ensure your Admin Dashboard can:

- View Serviced Vehicles: Fetch and display serviced vehicles using the /api/ServiceRecords/serviced endpoint. This will show vehicles that have completed service but are not yet dispatched.

- Dispatch Vehicle: Provide a way to dispatch a vehicle by making a PUT request to the /api/ServiceRecords/dispatch/{id} endpoint. This can be a button or action in your UI that sets the IsDispatched status to true.


# service advisor ki only branch 
3. Update the Service Advisor Dashboard UI
- Ensure your Service Advisor Dashboard can:

- View Scheduled Services: Fetch and display scheduled services for the logged-in service advisor using the /api/ServiceRecords/scheduled/{advisorId} endpoint.

- Update Bill of Materials: Provide a UI component for updating the Bill of Materials by making a PUT request to the /api/ServiceRecords/update-bom/{id} endpoint.

- Complete the Service: Provide an option to mark the service as completed by making a PUT request to the /api/ServiceRecords/complete/{id} endpoint.
# Service Record Controller
  // Endpoint to update the Bill of Materials
    [HttpPut("update-bom/{id}")]
    public async Task<IActionResult> UpdateBillOfMaterials(int id, [FromBody] UpdateBillOfMaterialsRequest request)
    {
        var serviceRecord = await _context.ServiceRecords.FindAsync(id);
        if (serviceRecord == null)
        {
            return NotFound();
        }

        if (serviceRecord.IsCompleted)
        {
            return BadRequest("Service has already been completed.");
        }

        serviceRecord.BillOfMaterials = request.BillOfMaterials;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    - Apply role-based authorization to the relevant controllers or actions.

    ```[Authorize(Policy = "AdminPolicy")]
[ApiController]
[Route("api/[controller]")]
public class AdminDashboardController : ControllerBase
{
    // Controller code here
}
```

```
[Authorize(Policy = "ServiceAdvisorPolicy")]
[ApiController]
[Route("api/[controller]")]
public class ServiceAdvisorDashboardController : ControllerBase
{
    // Controller code here
}
```

#  Test the Login Functionality

- Roles will be "Admin" and "ServiceAdvisor"
- You can test the login by making a POST request to /api/Auth/login with a username and password. 
If successful, you'll receive a JWT token. Use this token in the Authorization header as a Bearer token to access protected routes.
```
example login req
```
{
  "Username": "admin",
  "Password": "adminpassword"
}
```
example response
```
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

- YOu should seed some data in the db
```
public static void SeedData(ApplicationDbContext context)
{
    context.Users.AddRange(new List<User>
    {
        new User { Username = "admin", Password = "adminpassword", Role = "Admin" },
        new User { Username = "advisor", Password = "advisorpassword", Role = "ServiceAdvisor" }
    });
    context.SaveChanges();
}
```
