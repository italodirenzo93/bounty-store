import Vue from 'vue';
import VueRouter from 'vue-router';
import Home from './components/Home';
import BountyList from './components/BountyList';

Vue.use(VueRouter);

export default new VueRouter({
    routes: [
        { path: '/', component: Home },
        { path: '/bounties', component: BountyList },
    ]
});