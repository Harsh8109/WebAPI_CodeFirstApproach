function createEmployee() {
    var url = "/api/Employee";
    var employee = {};

    if ($("#txtFirstName").val() === '' || $("#txtLastName").val() === '' || $("#txtGender").val() === '' ||
        $("#txtCity").val() === '' || $("#txtIsActive").val() === '') {
        alert("Please fill all fields.");
    }
    else {
        employee.FirstName = $("#txtFirstName").val();
        employee.LastName = $("#txtLastName").val();
        employee.Gender = $("#txtGender").val();
        employee.City = $("#txtCity").val();
        employee.IsActive = $("#txtIsActive").val();

        // Make an Jquery's AJAX call to create the employee
        if (employee) {
            $.ajax({
                url: url,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(employee),
                type: "POST",
                success: function (result)
                {
                    clearForm();
                },

            
                error: function (msg)
                {
                    alert(msg);
                }

            });
        }
    }
}

function clearForm() {
    $("#txtFirstName").val('');
    $("#txtLastName").val('');
    $("#txtGender").val('');
    $("#txtCity").val('');
    $("#txtIsActive").val('');

}