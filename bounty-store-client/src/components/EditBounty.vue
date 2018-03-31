<template>
    <div class="container">
        <h1 class="display-4 text-center">Edit Bounty</h1>
        <bounty-form :bounty="bounty" @submit="updateBounty" @cancel="goBack"></bounty-form>
        <div v-show="success != null" class="text-center">
            <p v-show="success == true" class="text-success">Bounty has been updated!</p>
            <p v-show="success == false" class="text-danger">Unable to update bounty.</p>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
import BountyForm from './BountyForm';
import {apiEndpoint} from '../config';

export default {
    components: {
        BountyForm
    },
    data() {
        return {
            bounty: {},
            success: null
        };
    },
    created() {
        // Fetch the bounty data
        axios.get(apiEndpoint + '/' + this.$route.params.id)
            .then(res => this.bounty = res.data)
            .catch(() => this.success = false);
    },
    methods: {
        updateBounty(bounty) {
            // PUT request to API
            axios.put(apiEndpoint + '/' + this.$route.params.id, bounty)
                .then(() => this.$router.push({name: 'bounties'}))
                .catch(() => this.success = false);
        },
        goBack() {
            this.$router.push({name: 'bounties'});
        }
    }
};
</script>