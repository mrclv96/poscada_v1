import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'
import axios from 'axios'
import "./plugins/vuetify-mask.js";

Vue.config.productionTip = false
axios.defaults.headers['Content-Type'] = 'application/json;charset=utf-8';

//axios.defaults.headers.put['Content-Type'] = 'application/json;charset=utf-8';
axios.defaults.baseURL='https://localhost:44332/'
new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')




