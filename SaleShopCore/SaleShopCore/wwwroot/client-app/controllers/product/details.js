var ProductDetailController = function () {
    this.initialize = function () {
        registerEvents();
    }

    function registerEvents() {
        $('#btnAddToCart').on('click', function (e) {
            e.preventDefault();

            var productId = parseInt($(this).data('id'));
            var colorId = parseInt($('#ddlColorId').val());
            var sizeId = parseInt($('#ddlSizeId').val());
            var quantity = parseInt($('#txtQuantity').val());

            $.ajax({
                url: '/Cart/AddToCart',
                type: 'post',
                dataType: 'json',
                data: {
                    productId: productId,
                    quantity: quantity,
                    colorId: colorId,
                    sizeId: sizeId
                },
                success: function () {
                    alert(1);
                }
            });
        });
    }
}