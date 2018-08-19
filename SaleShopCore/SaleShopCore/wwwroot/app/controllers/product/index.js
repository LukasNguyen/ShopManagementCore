var productController = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
        loadCategories();
    }

    function registerEvents() {
        $('#ddlShowPage').on('change', function () {
            lukas.configs.pageSize = $(this).val();
            lukas.configs.pageIndex = 1;
            loadData(true);
        });

        $('#btnSearch').on('click', function () {
            loadData();
        });

        $('#txtKeyword').on('keypress', function (e) {
            if (e.which === 13) {
                loadData();
            }
        });
    }

    function loadCategories() {
        var template = $('#table-template').html();
        var render = "<option value=''>-- Select category --</option>";
        $.ajax({
            type: 'GET',
            url: '/admin/Product/GetAllCategories',
            dataType: 'json',
            success: function (response) {
                $.each(response, function (i, item) {
                    render += "<option value='"+ item.Id +"'>" + item.Name + "</option>"
                });

                $('#ddlCategorySearch').html(render);
            },
            error: function (status) {
                console.log(status);
                lukas.notify('Cannot load product category data', 'error');
            }
        });
    }

    function loadData(isPageChanged) {
        var template = $('#table-template').html();
        var render = "";
        $.ajax({
            type: 'GET',
            url: '/admin/Product/GetAllPaging',
            data: {
                categoryId: $('#ddlCategorySearch').val(),
                keyword: $('#txtKeyword').val(),
                page: lukas.configs.pageIndex,
                pageSize: lukas.configs.pageSize
            },
            dataType: 'json',
            success: function (response) {
                lukas.startLoading();
                $.each(response.Results, function (i, item) {
                    render += Mustache.render(template,
                        {
                            Id: item.Id,
                            Name: item.Name,
                            Image: item.Image == null ? '<img src="/admin-side/images/user.png" width=25/>' : '<img src="' + item.Image + '" width=25/>',
                            CategoryName: item.ProductCategory.Name ,
                            Price: lukas.formatNumber(item.Price, 0),
                            CreatedDate: lukas.dateTimeFormatJson(item.DateCreated),
                            Status: lukas.getStatus(item.Status)
                        });

                    $('#lblTotalRecords').text(response.RowCount);

                    if (render != '') {
                        $('#tbl-content').html(render);
                        lukas.stopLoading();
                    }
                    wrapPaging(response.RowCount, function () {
                        loadData();
                    }, isPageChanged);
                });
            },
            error: function (status) {
                console.log(status);
                lukas.notify('Cannot loading data', 'error');
            }
        });
    }
    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / lukas.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp',
            last: 'Cuối',
            onPageClick: function (event, p) {
                lukas.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }
}