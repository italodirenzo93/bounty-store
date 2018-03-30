<template>
    <div class="card bounty">
        <div class="card-body">
            <h5 class="card-title">{{bounty.name}}</h5>
            <h6 class="card-subtitle mb-2 text-muted">Alive: <span class="text-success">${{bounty.aliveReward}}</span></h6>
            <h6 class="card-subtitle mb-2 text-muted">Dead: <span class="text-danger">${{bounty.deadReward}}</span></h6>
            <p class="card-text">{{bounty.description}}</p>
            <a v-if="!bounty.captured" href="#" class="card-link" @click.prevent="claim">Claim</a>
            <span v-else class="card-link text-muted">Claimed</span>
            <router-link :to="{ name: 'edit', params: { id: bounty.id } }" class="card-link">Edit</router-link>
        </div>
    </div>
</template>

<script>
export default {
    props: {
        bounty: {
            type: Object,
            required: true
        }
    },
    methods: {
        claim() {
            this.$emit('claimed', this.bounty);
        }
    }
};
</script>
