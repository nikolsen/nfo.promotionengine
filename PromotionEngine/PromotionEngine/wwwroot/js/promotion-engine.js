$('.promotion-engine-calculate-cta').click(
	() => {
		var totalContainer = $('.promotion-engine-total');
		var value = $('.promotion-engine input.promotion-engine-skus-input').val().toUpperCase().replace(/ /g, '');

		$.ajax({
			url: '/api/OrderTotalCalculation?skus=' + value,
			success: (response) => { totalContainer.html('Total: ' + response); },
			error: (response) => { totalContainer.html('Error occurred, check your input data'); },
			dataType: 'json'
		});
	}
)
