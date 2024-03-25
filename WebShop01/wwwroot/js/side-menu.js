var sideMenu = new Vue({
    el: "#side-menu",
    data: {
        showSideMenu: false,
        showServices: false,
        showPartnerInfo: false,
        showUserInfo: false
    },
    mounted() {
    },
    methods: {
        sideMenuVisible() {
            if (!this.showSideMenu) {
                this.showSideMenu = true;
            }
            else {
                this.showSideMenu = false;
            }
        },
        servicesVisible() {
            if (!this.showServices) {
                this.showServices = true;
            }
            else {
                this.showServices = false;
            }
        },
        partnerInfoVisible() {
            if (!this.showPartnerInfo) {
                this.showPartnerInfo = true;
            }
            else {
                this.showPartnerInfo = false;
            }
        },
        userInfoVisible() {
            if (!this.showUserInfo) {
                this.showUserInfo = true;
            }
            else {
                this.showUserInfo = false;
            }
        }
    }
})


