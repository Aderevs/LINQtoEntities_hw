var categoryProduct = new Vue({
    el: "#last-product",
    data: {
        noFoundImage: "https://localhost:44347/img/NotFind.png",
        loaded: false,
        header: "Останні переглянуті товари",
        products: [],
        expandListShow: false,
        url: "/api/products/",
    },
    created() {
        this.Loaded();
    },
    methods: {
        ShowAllList() {
            this.expandListShow = true;
        },
        Loaded() {
            axios.get(this.url).then((response) => {
                this.products = response.data;
                this.loaded = true;
                console.log(this.products);
                if (this.products.length < 6) {
                    this.expandListShow = true;
                }

            }).catch(function (error) {
                if (error.response) {
                    console.log(error.response.status);
                }
            });
        },
        ErrorLoadImage(e) {
            e.target.src = this.noFoundImage;
        }
    }
})