function FillSubGroup() {
    var stateId = $('#GroupId').val();

    $.ajax({
        url: '/Home/GetSubGroupById',
        type: "GET",
        dataType: "JSON",
        data: { id: stateId },
        success: function (states) {

            $("#SubGroupId").html('<option value="" >Select SubGroup</option>'); // clear before appending new list 
            $.each(states, function (i, state) {
                $("#SubGroupId").append(
                    $('<option></option>').val(state.Id).html(state.SubGroupName));
            });
        }

    });
}
function FillPreparate() {
    var stateId = $('#SubGroupId').val();

    $.ajax({
        url: '/Home/GetPreparateBySubId',
        type: "GET",
        dataType: "JSON",
        data: { id: stateId },
        success: function (states) {

            $("#PreparateId").html('<option value="" >Select SubGroup</option>'); // clear before appending new list 
            $.each(states, function (i, state) {
                $("#PreparateId").append(
                    $('<option></option>').val(state.Id).html(state.PreparateName));
            });
        }

    });
}



