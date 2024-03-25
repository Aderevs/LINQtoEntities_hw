var mainHeader = new Vue({
    el: "#main-header",
    data: {
        showSeachHistory: false,
        search: "",
        url: "/api/search/",
        find: []
    },
    watch: {
        search: function () {
            this.Request()
        }
    },
    methods: {
        Request() {
            var params = new URLSearchParams();
            params.append("word", this.search);

            axios.get(this.url, { params }).then((response) => {
                this.find = response.data;
                console.log(this.find)
            }).catch(function (error) {
                if (error.response) {
                    console.log(error.response.status);
                }
            });
        },
        showSideMenu() {
            sideMenu.sideMenuVisible();
        },
        showSearchHistory() {
            this.showSeachHistory = true;
        },
        hideSearchHistory() {
            this.showSeachHistory = false;
        }
    }
})

