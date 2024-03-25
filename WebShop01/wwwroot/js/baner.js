var baner = new Vue({
    el: "#baner",
    data: {
        carouselElement: null,
        carouselTimer: null,
        carouselLength: 0,
        carouselCurrent: 0,
        carouselInterval: 7000,
        carouselStart: true,
    },
    mounted() {
        this.carouselElement = this.$refs.items;
        this.carouselLength = this.carouselElement.children.length;
        this.carouselElement.style.width = (100 * this.carouselLength) + "%";
        if (this.carouselStart) {
            this.TimerSwipe();
        }
    },
    watch: {
        carouselCurrent: function () {
            if (this.carouselCurrent >= this.carouselLength) {
                this.carouselCurrent = 0;
            }
            if (this.carouselCurrent < 0) {
                this.carouselCurrent = this.carouselLength - 1;
            }
            this.carouselElement.style.left = (-100 * this.carouselCurrent) + "%";
        }
    },
    methods: {
        TimerSwipe() {
            this.carouselTimer = setInterval(() => {
                this.SwipeNext();
            }, this.carouselInterval);
        },
        SwipeNext() {
            this.carouselCurrent++;
        },
        SwipeBefore() {
            this.carouselCurrent--;
        },
        BanerOver() {
            clearInterval(this.carouselTimer);
        },
        BanerLeave() {
            this.TimerSwipe();
        }
    }
})