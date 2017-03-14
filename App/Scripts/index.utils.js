(function ($) {
    /* Variables */

    var token = $("input[name='__RequestVerificationToken']").val(); //Get CRSF token
    var searchInput = $(".form-group input") ;    // Search input value
    var entity = "/" + $("#index").attr("data-entity");   // Entity type  
    var id;           // Selected entity id

    /* Methods */

    //Page load method
    var load = function (page, search) {
        $("#index").load(entity + "/PartialIndex/", { page: page, search: search });
    };
    
    /* Table events */

    //Request first page when page loads 
    $(document).ready(function () {
        load(1,"");
    });

    //Page navigation   
    $(document).on("click", ".pagination li", function () {
        load($(this).text(), searchInput.val());
    });

    //Row selection
    $(document).on("click", "tr", function () {
        $("tbody tr").removeClass("success");
        $(this).addClass("success");
        id = $(this).attr("data-id");
    });     

    /* Entity events */

    //Search method
    $("button[name='search']").click(function () {
        console.log(searchInput.val());
        load(1, searchInput.val());
    });
      
    //Pick a object to edit
    $("a[data-action='Edit']").click(function () {
        if (id)
            window.location.href = entity + "/Edit/" + id;
        else
            alert("Selecione um item");
    });

    //Pick a object to delete
    $("a[data-action='Delete']").click(function () {
        if (id) {
            var q = confirm("Deseja realmente deletar esse registro ?");
            if (q) {
                var url = entity + "/Delete/";
                $.post(url, { id: id, __RequestVerificationToken: token });
            }
        }
        else
            alert("Selecione um item");
    });
})(jQuery);
