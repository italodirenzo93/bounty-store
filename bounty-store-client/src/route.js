import Vue from 'vue';
import VueRouter from 'vue-router';

import BountyList from './components/BountyList';
import NewBounty from './components/NewBounty';
import EditBounty from './components/EditBounty';

Vue.use(VueRouter);

export default new VueRouter({
    routes: [
        { path: '/', name: 'bounties', component: BountyList },
        { path: '/new', name: 'new', component: NewBounty },
        { path: '/edit/:id', name: 'edit', component: EditBounty }
    ]
});