
var ge = new Vue({
    el: '#geSearch',
    data: {
        searchText: '',
        items: [],
        selectedItem: null,
        isSearching: false,
        showSearch: true
    },
    watch: {
        searchText: function (data) {
            this.isSearching = true;
            if (data.length > 0)
                this.showSearch = true;
            this.items = rs_objects.filter(obj => {
                return obj.name.toLowerCase().search(this.searchText.toLowerCase()) >= 0;
            });
            this.isSearching = false;
        }
    },
    methods: {
        getItem: function (id) {
            this.items = [];
            var self = this;
            this.showSearch = false;
            fetch("item/" + id, { method: 'GET' }).then(function (resp) {
                return resp.json();
            }).then(
                function (data) {
                    var jsonData = JSON.parse(data);
                    self.searchText = '';
                    self.selectedItem = jsonData[0].item;
                    var priceArr = [{type: 'line', dataPoints: []}];
                    for (var m in jsonData[1].daily) {
                        if (jsonData[1].daily.hasOwnProperty(m)) {
                            priceArr[0].dataPoints.push({
                                y: jsonData[1].daily[m],
                                x: new Date(parseInt(m))
                            });
                        }
                    }
                    var chart = new CanvasJS.Chart("itemPrices",
                    {
                        theme: "light2",
                        width: 1000,
                        height: 400,
	                    title: {
		                    text: jsonData[0].item.name + " daily prices",
	                    },
                        axisX:{
		                    valueFormatString: "MM/DD/YYYY",
		                    crosshair: {
			                    enabled: true,
			                    snapToDataPoint: true
		                    }
	                    },
	                    axisY: {
		                    title: "Price in GP",
		                    crosshair: {
			                    enabled: true
		                    }
	                    },
                        data: priceArr
                    });
                    chart.render();
                }
            );
        }
    }
});