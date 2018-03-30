import Vue from 'vue';
import VueRouter from 'vue-router';
import Home from './components/Home';

import BountyList from './components/BountyList';
import EditBounty from './components/EditBounty';

Vue.use(VueRouter);

export default new VueRouter({
    routes: [
        { path: '/', component: Home },
        { path: '/bounties', component: BountyList },
        { path: '/edit/:id', name: 'edit', component: EditBounty }
    ]
});