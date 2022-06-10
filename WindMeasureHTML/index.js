const baseUrl = "http://localhost:50927/api/WindMeasure";

Vue.createApp({
    data() {
        return {
            windMeasures: [],
            minimumSpeed: 0
        }
    },
    async created() { // life cycle method. Called when browser reloads page
        //try {
        //const response = await axios.get(baseUrl)
        //this.coolers = await response.data
        //} catch (ex) {
        //    alert(ex.message)
        //}
        this.getAllData()
    },
    methods: {
        async getAllData() {
            try {
                response = await axios.get(baseUrl)
                this.windMeasures = await response.data
            } catch (ex) {
                alert(ex.message)
            }
        },
        async getAllDataFiltered() {
            try {
                response = await axios.get(baseUrl + "?minimumSpeed=" + this.minimumSpeed)
                this.windMeasures = await response.data
            } catch (ex) {
                alert(ex.message)
            }
        },
        filterData(minimumSpeed) {
            this.windMeasures = this.windMeasures.filter(function (windMeasure) {
                return windMeasure.windSpeed >= minimumSpeed
            })
        }
    }
}).mount("#app")