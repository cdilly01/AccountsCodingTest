//Validation configs
var config = {
    errorBagName: 'errors', // change if property conflicts
    fieldsBagName: 'fields',
    delay: 0,
    locale: 'en',
    dictionary: null,
    strict: true,
    classes: false,
    classNames: {
        touched: 'touched', // the control has been blurred
        untouched: 'untouched', // the control hasn't been blurred
        valid: 'valid', // model is valid
        invalid: 'validationMessage', // model is invalid
        pristine: 'pristine', // control has not been interacted with
        dirty: 'dirty' // control has been interacted with
    },
    events: 'input|blur',
    inject: true,
    validity: false,
    aria: true,
    i18n: null, // the vue-i18n plugin instance
    i18nRootKey: 'validations' // the nested key under which the validation messsages will be located
};
//Vue.use(Vuex);
Vue.use(Vuetify, { iconfont: 'fa' });
Vue.use(VeeValidate, config);
Vue.use(VueTheMask.default);

//datepicker component
Vue.component('datemenupicker', {
    template: `
                <v-menu :close-on-content-click="false" attach v-model="menuState" ref="menuState" min-width="290" offset-y bottom middle>

                    <template v-slot:activator="{ on }">
                        <v-text-field v-model="timeFormatted" 
                                      v-on:click:clear="updateValue" 
                                      :error-messages="errorMessages" 
                                      :label="label"
                                      v-on="on" readonly clearable hide-details append-icon="mdi-calendar">
                        </v-text-field>
                    </template>

                    <v-date-picker v-model="editableDate" v-on:change="menuState = false"></v-date-picker>
                </v-menu>
            `,
    props: ["value", "label"],
    data() {
        return {
            internalValue: null,
            editableDate: null,

            menuState: false,
            timeFormatted: "",
            errorMessages: null
        };
    },
    methods: {
        updateValue() {
            if (this.editableDate) {
                this.timeFormatted = moment(this.editableDate).format('MMM DD YYYY');
            } else {
                this.timeFormatted = "";
            }

            this.$emit('input', this.timeFormatted);
        }
    },
    watch: {
        editableDate() {
            this.updateValue();
        },
        editableTime() {
            this.updateValue();
        }
    },
    mounted() {
        if (this.value)
            this.editableDate = moment(this.value).format("YYYY-MM-DD");
    }
});

var accountsDetail = function (model) {
    return {
        el: "#app",
        vuetify: new Vuetify(),
        data: {
            model: model.AccountsModel,
            statusList: model.StatusList,

            //validation
            requiredRules: [
                v => !!v || 'Required'
            ],
            requiredMaxLengthRules: [
                v => !!v || 'Required',
                v => v.length <= 200 || 'Must be less than 200 characters'
            ],
            maxLengthRules: [
                v => {

                    if (v !== null && v !== undefined && v.length > 0)
                        return v.length <= 200 || 'Must be less than 200 characters';
                    else
                        return true;
                }
            ],
        },
        computed: {},
        methods: {
            save() {
                var test = this;
                this.$validator.validateAll().then((result) => {
                    if (result) {
                        var formData = new FormData();

                        this.overlay = true;
                        axios.post(this.url + '/Accounts/Save/' + this.projectId, formData)
                            .then(function (response) {
                                model.overlay = false;

                                if (response.data.success === true) {
                                }
                            })
                            .catch(function (error) {
                                console.log(error);
                            })
                            .finally(function () {
                                test.overlay = false;

                            });

                        console.log(formData);
                        return;
                    }
                });
            },
            cancel() {
                //window.location.href = this.returnUrl;
                return;
            },
        }
    };
};