var lastProduct = new Vue({
    el: "#category-product",
    data: {
        noFoundImage: "https://localhost:44347/img/NotFind.png",
        url: "/api/category/",
        category: null,
        loaded: false,
        products: [],
        selections: [],
        checked: [],
        min: 0,
        max: 0
    },
    mounted() {
        const pathArray = window.location.pathname.split("/");
        this.category = pathArray[pathArray.length - 1];

        this.max = this.$refs.inputMax.value;
        this.min = this.$refs.inputMin.value;

        this.Request();
    },
    watch: {
        checked: function () {
            this.Request();
        },
        //min: function () {
        //    if (this.max < this.min) {
        //        this.max = this.min;
        //    }
        //},
        //max: function () {
        //    if (this.max < this.min) {
        //        this.max = this.min;
        //    }
        //}
    },
    methods: {
        Request() {
            this.loaded = false;
            var params = new URLSearchParams();
            params.append("category", this.category);
            params.append("max", this.max);
            params.append("min", this.min);
            this.checked.forEach(keyword => {
                params.append("keywords", keyword);
            });
            
            axios.get(this.url, { params }).then((response) => {
                this.products = response.data;
                this.loaded = true;
            }).catch(function (error) {
                if (error.response) {
                    console.log(error.response.status);
                }
            });
        },
        ErrorLoadImage(e) {
            e.target.src = this.noFoundImage;
        },
        ChangeCheckBox(e) {
            console.log(e.currentTarget)
        },
        Check(e) {
            let val = e.target.value;
            let find = this.checked.indexOf(val);
            if (find == -1) {
                this.checked.push(val);
            }
            else {
                this.checked.splice(find, 1);
            }
            console.log(this.checked);
        }

    }
})



