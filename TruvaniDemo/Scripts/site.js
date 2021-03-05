(function () {
    var cartItems = [];
    $('button[data-id]').on('click', function () {
        var id = $(this).attr('data-id');
        

        cartItems.push(id);

        $.ajax({
            url: '/Home/Recommended',
            data: { id: id, cartTotal: 68 },
            type: 'GET',
            contentType: 'html',
            success: function () {
                console.log('success');
            },
            error: function (er) {
                console.log('err', er)
            }
        });
    });
})();