//const { error } = require("jquery");

$(document).ready(function () {
    $('.del').on("click", function () {
        var btn = $(this);
        //console.log(btn.data('id'));
        const swal = Swal.mixin({
            customClass: {
                confirmButton: "btn btn-danger mx-2",
                cancelButton: "btn btn-light"
            },
            buttonsStyling: false
        });
        swal.fire({
            title: "Are you sure you want to delete this game?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel!",
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: '/Game/Delete/' + btn.data('id'),
                    method: 'DELETE',
                    success: function () {
                        swal.fire({
                            title: "Deleted!",
                            text: "Your file has been deleted.",
                            icon: "success"
                        });
                        btn.parents('tr').fadeOut();
                    },
                    error: function () {
                        swal.fire({
                            title: "Error!!!",
                            text: "Something wrong happened.",
                            icon: "error"
                        }); }
                });
               
            //} else if (
            //    /* Read more about handling dismissals below */
            //    result.dismiss === Swal.DismissReason.cancel
            //) {
            //    swalWithBootstrapButtons.fire({
            //        title: "Cancelled",
            //        text: "Your imaginary file is safe :)",
            //        icon: "error"
            //    });
            }
        });
        

    });
});